using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Orb : MonoBehaviour
{
	[SerializeField] private new ParticleSystem particleSystem;
	[SerializeField] private float speed = 0.01f;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private int prize;
	[SerializeField] private GameObject _explosionEffect;
	private bool isDestroyed = false;
	
	private void Start()
	{
		spriteRenderer.color = GenerateColor();
		GetRandomSprite();
	}
	
	private void FixedUpdate()
	{
		var newPosition = new Vector2(transform.position.x, transform.position.y - speed);
		transform.position = newPosition;
	}
	
	public void Pop()
	{
		if (isDestroyed) return;
		AudioEvent.RaiseEvent(AudioTypes.Pop);
		isDestroyed = true;
		GameController._points += prize;
		ProcessPop();
		speed = 0;
		PlayDeath();
	}
	
	public void PlayDeath()
	{
		StartCoroutine(PlayEffect());
	}
	
	private IEnumerator PlayEffect()
	{
		spriteRenderer.enabled = false;
		var effect = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
		if (particleSystem != null)
		{
			particleSystem.Clear();
			Destroy(particleSystem);
		}
		yield return new WaitForSeconds(2);
		Destroy(effect);
		Destroy(gameObject);
	}
	
	private void GetRandomSprite()
	{
		var rnd = Random.Range(0, 19);
		
		spriteRenderer.sprite = GameController.PlanetsSprites[rnd];
	}
	
	protected abstract void ProcessPop();
	protected abstract Color GenerateColor();
}
