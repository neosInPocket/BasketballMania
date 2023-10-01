using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRoutine : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<Orb>(out Orb orb))
		{
			orb.Pop();
		}
	}
}
