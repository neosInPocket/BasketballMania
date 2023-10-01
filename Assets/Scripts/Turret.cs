using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Turret : MonoBehaviour
{
	private int multiplier = 1;
	private float _rotationSpeed
	{
		get
		{
			if (MainMenuController.CurrentRotationSpeed == 0) return 0.7f * multiplier;
			if (MainMenuController.CurrentRotationSpeed == 1) return 1 * multiplier;
			return MainMenuController.CurrentRotationSpeed / 1.5f * multiplier;
		}
	}
	[SerializeField] private List<GameObject> _upgrades;
	[SerializeField] private List<GameObject> _lasers; 
	
	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}
	
	private void Start()
	{
		// UnlockUpgrades();
		Touch.onFingerDown += OnFingerDownHandler;
		Touch.onFingerUp += OnFingerUpHandler;
	}
	
	private void OnFingerDownHandler(Finger finger)
	{
		// if (GameController._isPlaying)
		// {
			EnableLasers(true);
			AudioEvent.RaiseEvent(AudioTypes.Laser);
			multiplier *= -1;
		//}
		Debug.Log("Turret down");
	}
	
	private void OnFingerUpHandler(Finger finger)
	{
		//EnableLasers(false);
		Debug.Log("Turret up");
	}
	
	private void EnableLasers(bool value)
	{
		foreach(var laser in _lasers)
		{
			if (laser.activeSelf)
			{
				laser.GetComponent<LineRenderer>().enabled = value;
				laser.GetComponent<BoxCollider2D>().enabled = value;
			}
		}
	}
	
	private void FixedUpdate()
	{
		transform.Rotate(0, 0, -_rotationSpeed);
	}
	
	public void UnlockUpgrades()
	{
		for (int i = 0; i < MainMenuController.CurrentLaserUpgrade; i++)
		{
			try
			{
				_upgrades[i].SetActive(true);
			}
			catch
			{
				Debug.LogError("Out of upgrades list");
			}
			
		}
	}
	
	private void OnDestroy()
	{
		TouchSimulation.Enable();
	}
}
