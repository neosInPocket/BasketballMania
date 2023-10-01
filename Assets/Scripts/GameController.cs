using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour
{
	[SerializeField] private TutorialScreen _tutor;
	[SerializeField] private UIHealth _uiHealth; 
	[SerializeField] private Turret _turret; 
	[SerializeField] private GameObject turretGO;
	[SerializeField] private FadeScreen _fadeScreen;
	[SerializeField] private MainMenuController _mainMenuController;
	[SerializeField] private GameScreen _gameScreen;
	[SerializeField] private WinScreen _countDownScreen; 
	[SerializeField] private WinScreen _defeatScreen; 
	[SerializeField] private WinScreenWithCoins _winScreen; 
	[SerializeField] private ProgressBar _levelProgress;
	[SerializeField] List<GameObject> _spawnAreas;
	[SerializeField] List<Orb> _orbs;
	[SerializeField] private GameObject _orbsContainer; 
	[SerializeField] private int _spawnDelay = 1; 
	[SerializeField] private GameObject deathZone;
	public static Sprite[] PlanetsSprites;
	private float _playDelay;
	public static int _levelCoins;
	private static int _levelMaxPoints;
	public static int _points;
	private bool _isSpawning;
	public static bool _isPlaying = false;
	public static int lives;
	public const int maxLives = 3;
	private bool isTutor = false;
	
	
	private void Awake()
	{
		_isPlaying = false;
	}
	
	private void Update()
	{
		if (!_isPlaying) return;
		if (_isSpawning) return;
		StartCoroutine("Spawn");
	}
	
	public void Initialize()
	{
		_isPlaying = false;
		turretGO.gameObject.SetActive(true);
		deathZone.gameObject.SetActive(true);
		
		GameEventHandler.OnEvent += OnEventHandler;
		RefreshTurretUpgrades();
		lives = maxLives;
		DeleteOrbs();
		_levelMaxPoints = (int)(Mathf.Log(MainMenuController.CurrentLevel + 2) * 5);
		_levelCoins = (int)(Mathf.Log(MainMenuController.CurrentLevel + 2) * 10) + 50;
		_gameScreen.gameObject.SetActive(true);
		_gameScreen.Refresh();
		_levelProgress.Refresh(0);
		_points = 0;
		_playDelay = (int)_countDownScreen.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
		_uiHealth.RefreshLifes(lives);
		isTutor = false;
		
		if (MainMenuController.IsFirstTime == "yes")
		{
			MainMenuController.IsFirstTime = "no";
			SaveLoad.Save();
			isTutor = true;
			_tutor.PlayTutor();
		}
		else
		{
			_countDownScreen.gameObject.SetActive(true);
			_countDownScreen.Show();
		}
		
		
		StartCoroutine(PlayDelay());
	}
	
	private void RefreshTurretUpgrades()
	{
		_turret.UnlockUpgrades();
	}
	
	private void OnEventHandler(bool value)
	{
		if (!_isPlaying) return;
		
		if (!value)
		{
			_fadeScreen.ProcessTakeDamage();
			_uiHealth.RefreshLifes(lives);
		}
		
		_levelProgress.Refresh((float)_points / (float)_levelMaxPoints);
		
		if (_points >= _levelMaxPoints)
		{
			_isPlaying = false;
			MainMenuController.CurrentLevel++;
			MainMenuController.Coins += _levelCoins;
			SaveLoad.Save();
			_winScreen.gameObject.SetActive(true);
			_winScreen.Show(_levelCoins);
			DeleteOrbs();
			return;
		}
		
		if (lives <= 0)
		{
			_isPlaying = false;
			_points = 0;
			_defeatScreen.gameObject.SetActive(true);
			_defeatScreen.Show();
			DeleteOrbs();
			return;
		}
	}
	
	public void ReturnToTheMainMenu()
	{
		_fadeScreen.Fade();
		_fadeScreen.OnFadeEnd += OnFadeMainMenuEnd;
		
	}
	
	private void OnFadeMainMenuEnd()
	{
		_fadeScreen.OnFadeEnd -= OnFadeMainMenuEnd;
		_gameScreen.gameObject.SetActive(false);
		_mainMenuController.Initialize();
	}
	
	private IEnumerator PlayDelay()
	{
		if (isTutor)
		{
			_playDelay = 18f;
		}
		yield return new WaitForSeconds(_playDelay + 0.5f);
		_countDownScreen.gameObject.SetActive(false);
		_isPlaying = true;
	}
	
	private IEnumerator Spawn()
	{
		_isSpawning = true;
		Instantiate(GetRandomOrb(), GetRandomSpawnPoint(), Quaternion.identity, _orbsContainer.transform);
		yield return new WaitForSeconds(_spawnDelay);
		_isSpawning = false;
	}
	
	public void UpdateUI()
	{
		var progress = _points / _levelMaxPoints;
		_levelProgress.Refresh(progress);
	}
	
	private Vector2 GetRandomSpawnPoint()
	{
		var rnd = new Random();
		GameObject spawnArea = _spawnAreas[rnd.Next(0, _spawnAreas.Count)];
		
		Vector3 areaPosition = spawnArea.transform.position;
		Vector3 areaSize = spawnArea.GetComponent<Renderer>().bounds.size;
		
		float randomX = UnityEngine.Random.Range(areaPosition.x - areaSize.x/2, areaPosition.x + areaSize.x/2);
		float randomY = UnityEngine.Random.Range(areaPosition.y - areaSize.y/2, areaPosition.y + areaSize.y/2);
		
		return new Vector2(randomX, randomY);
	}
	
	private Orb GetRandomOrb()
	{
		var rnd = new Random();
		Orb orb = _orbs[rnd.Next(0, _orbs.Count)];
		return orb;
	}
	
	private void DeleteOrbs()
	{
		foreach (Transform child in _orbsContainer.transform)
		{
			if (child.TryGetComponent<Orb>(out Orb orb)) orb.GetComponent<Orb>().PlayDeath();
		}
	}

}
