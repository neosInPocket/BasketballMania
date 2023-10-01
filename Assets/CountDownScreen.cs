using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownScreen : MonoBehaviour
{
	[SerializeField] private Animator animator;
	public virtual void Show()
	{
		animator.SetTrigger("ShowCount");
	}
	
	public void Hide()
	{
		animator.SetTrigger("Disable");
	}
}
