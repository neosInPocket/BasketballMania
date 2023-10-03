using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject effect;
	[SerializeField] private SpriteRenderer spriteRenderer;
	private bool _isDestroyed;
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (_isDestroyed) return;
		
		if (collider.TryGetComponent<PlayerBall>(out PlayerBall player))
		{
			_isDestroyed = true;
			GameController._points += 2;
			GameEventHandler.RaiseEvent(true);
			PlayDeath();
		}
	}
	
	public void PlayDeath()
	{
		StartCoroutine(PlayEffect());
	}
	
	private IEnumerator PlayEffect()
	{
		spriteRenderer.color = new Color(0, 0, 0, 0);
		var deathEffect = Instantiate(effect, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1f);
		Destroy(deathEffect);
		Destroy(this.gameObject);
	}
}
