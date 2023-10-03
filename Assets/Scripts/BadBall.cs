using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BadBall : MonoBehaviour
{
	private Transform _playerBall;
	[SerializeField] private Vector2 _spawnPosition;
	[SerializeField] private Rigidbody2D _rb; 
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _maxDistance; 
	[SerializeField] private float _acceleration;
	[SerializeField] private GameObject _deathEffect;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	private Vector2 _destination;
	private float _currentSpeed;
	private float MaxSpeed;
	
	public Transform Player 
	{
		get => _playerBall;
		set => _playerBall = value;
	}
	
	private void Start()
	{
		MaxSpeed = Mathf.Log(MainMenuController.CurrentLevel + 20) - 2.5f;
	}
	
	public void SetPosition()
	{
		transform.localPosition = _spawnPosition;
	}
	
	private void FixedUpdate()
	{
		if (_playerBall == null || !GameController._isPlaying)
		{
			_rb.velocity = Vector2.zero;
			return;
		};
		
		Vector3 lookDir = _playerBall.position - transform.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0f, 0f, angle);
		
		if (_currentSpeed > MaxSpeed)
		{
			_currentSpeed = MaxSpeed;
			_rb.velocity = _currentSpeed * transform.right;
			return;
		}
		
		_currentSpeed += _acceleration;
		_rb.velocity = _currentSpeed * transform.right;
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<PlayerBall>(out PlayerBall player))
		{
			if (player._isInvincible) return;
			
			player._isInvincible = true;
			player.PlayDeath(false);
		}
	}
	
	public void PlayDeath()
	{
		StartCoroutine(PlayDeathEffect());
	}
	
	private IEnumerator PlayDeathEffect()
	{
		_spriteRenderer.color = new Color(0, 0, 0, 0);
		var effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1f);
		Destroy(effect);
		Destroy(this.gameObject);
	}
}
