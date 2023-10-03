using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Image deathZoneArrow; 
	[SerializeField] private Image enemyArrow; 
	[SerializeField] private Image turretArrow;
	[SerializeField] private Image character;
	[SerializeField] private Image back;	
	
	public void PlayTutor()
	{
		StartCoroutine(Tutor());
	}
	
	private IEnumerator Tutor()
	{
		_text.text = "Welcome to PinIt Tips: Cricket Games!";
		_text.gameObject.SetActive(true);
		back.gameObject.SetActive(true);
		character.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		
		_text.text = "Here is your ball. Move it with touching your screen!";
		_text.gameObject.SetActive(true);
		turretArrow.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		turretArrow.gameObject.SetActive(false);
		
		_text.text = "Your goal is to avoid moving nets and chasing ball";
		_text.gameObject.SetActive(true);
		enemyArrow.gameObject.SetActive(true);
		yield return new WaitForSeconds(4);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		enemyArrow.gameObject.SetActive(false);
		
		_text.text = "Collect coins and buy upgrades in shop, such as max lives amount";
		_text.gameObject.SetActive(true);
		deathZoneArrow.gameObject.SetActive(true);
		yield return new WaitForSeconds(4);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		deathZoneArrow.gameObject.SetActive(false);
		
		_text.text = "Good luck!";
		_text.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		gameObject.SetActive(false);
	}
}
