using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePieceRenderer : MonoBehaviour
{
	[SerializeField] private Collider2D _collider;
	[SerializeField] private bool _isVertical; 
	public Action TriggerEnter;
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.TryGetComponent<VerticalLineTrigger>(out VerticalLineTrigger verticalTrigger) && _isVertical)
		{
			TriggerEnter.Invoke();
		}
		
		if (collider.gameObject.TryGetComponent<HorizontalLineTrigger>(out HorizontalLineTrigger horizontalTrigger) && !_isVertical)
		{
			TriggerEnter.Invoke();
		}
		
		if (collider.gameObject.TryGetComponent<PlayerBall>(out PlayerBall player))
		{
			if (player._isDestroyed) return;
			
			player._isDestroyed = true;
			player.PlayDeath();
		}
	}
}
