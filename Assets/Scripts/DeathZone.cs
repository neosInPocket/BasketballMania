using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<Orb>(out Orb orb))
		{
			if (orb.GetType() == typeof(BadOrb))
			{
				orb.PlayDeath();
				return;
			} 
			GameController.lives--;
			GameEventHandler.RaiseEvent(false);
			orb.PlayDeath();
		}
	}
}
