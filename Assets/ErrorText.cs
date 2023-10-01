using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorText : MonoBehaviour
{
	[SerializeField] private Animator animator;
	
	public void Error()
	{
		animator.SetTrigger("Error");
	}
}
