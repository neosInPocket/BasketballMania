using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
	[SerializeField] private VerticalLineRenderer _verticalLine;
	[SerializeField] private HorizontalLineRenderer _horizontalLine;
	
	public void Initialize()
	{
		SpawnHorizontal();
		SpawnVertical();
	}
	
	public void SpawnHorizontal()
	{
		Instantiate(_horizontalLine, transform.position, quaternion.identity);
	}
	
	public void SpawnVertical()
	{
		Instantiate(_verticalLine, transform.position, quaternion.identity);
	}
}
