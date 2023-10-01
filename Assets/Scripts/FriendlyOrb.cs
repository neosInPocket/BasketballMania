using UnityEngine;
using Random = UnityEngine.Random;

public class FriendlyOrb : Orb
{

	protected override Color GenerateColor()
	{
		return Color.white;
	}

	protected override void ProcessPop() 
	{ 
		GameEventHandler.RaiseEvent(true);
	}
} 
