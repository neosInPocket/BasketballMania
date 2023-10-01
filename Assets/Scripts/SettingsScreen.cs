using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
	[SerializeField] private Scrollbar musicScrollbar;
	[SerializeField] private Scrollbar fxScrollbar;
	[SerializeField] private Animator animator;
	[SerializeField] private AudioController audioController;
	
	private void Start()
	{
		musicScrollbar.value = audioController.volume;
	}
	
	public void Hide()
	{
		animator.SetTrigger("Hide");
	}
	
	public void Disable()
	{
		gameObject.SetActive(false);
	}
}
