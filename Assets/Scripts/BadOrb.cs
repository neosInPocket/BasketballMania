using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BadOrb : Orb
{
	protected override Color GenerateColor()
	{
		float r = Random.Range(0.6f, 0.8f);
		float g = Random.Range(0.6f, 0.8f);
		float b = Random.Range(0.6f, 0.8f);
		
		return new Color(r, g, b);
	}

	protected override void ProcessPop()
	{
		GameController.lives--;
		
		GameEventHandler.RaiseEvent(false);
	}
}
