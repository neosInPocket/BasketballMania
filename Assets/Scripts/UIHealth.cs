
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIHealth : MonoBehaviour
{
	[SerializeField] private List<Image> _lifes;
	
	public void RefreshLifes(int value)
	{
		foreach (var life in _lifes)
		{
			life.color = new Color(0, 0, 0, 1f);
		}
		
		for (int i = 0; i < value; i++)
		{
			_lifes[i].color = new Color(1, 1, 1, 1f);
		}
	}
}
