using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BadBall : MonoBehaviour
{
	[SerializeField] private Transform _playerBall;
	[SerializeField] private Vector2 _spawnPosition;
	[SerializeField] private Rigidbody2D _rb; 
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _maxDistance; 
	[SerializeField] private float _acceleration;
	[SerializeField] private GameObject _deathEffect;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	private Vector2 _destination;
	private float _currentSpeed;
	
	public void SetPosition()
	{
		transform.localPosition = _spawnPosition;
	}
	
	private void FixedUpdate()
	{
		if (_playerBall == null)
		{
			_rb.velocity = Vector2.zero;
			return;
		};
		
		Vector3 lookDir = _playerBall.position - transform.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0f, 0f, angle);
		
		if (_currentSpeed > _maxSpeed)
		{
			_currentSpeed = _maxSpeed;
			_rb.velocity = _currentSpeed * transform.right;
			return;
		}
		
		_currentSpeed += _acceleration;
		_rb.velocity = _currentSpeed * transform.right;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<PlayerBall>(out PlayerBall player))
		{
			if (player._isDestroyed) return;
			
			player._isDestroyed = true;
			player.PlayDeath();
			_maxSpeed = 0;
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
