using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Image deathZoneArrow; 
	[SerializeField] private Image turretArrow;
	[SerializeField] private Image character;
	[SerializeField] private Image back;	
	
	public void PlayTutor()
	{
		StartCoroutine(Tutor());
	}
	
	private IEnumerator Tutor()
	{
		_text.text = "Welcome to Laser Beam!";
		_text.gameObject.SetActive(true);
		back.gameObject.SetActive(true);
		character.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		
		_text.text = "Press on the screen to make turret shoot with lasers";
		_text.gameObject.SetActive(true);
		turretArrow.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		turretArrow.gameObject.SetActive(false);
		
		_text.text = "Your goal is to pop orbs and avoid popping comets with trails";
		_text.gameObject.SetActive(true);
		yield return new WaitForSeconds(4);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		
		_text.text = "If orb reaches red zone, you will lose your health";
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
