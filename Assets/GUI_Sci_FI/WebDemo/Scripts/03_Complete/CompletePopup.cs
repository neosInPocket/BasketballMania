using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CompletePopup : MonoBehaviour {
	
	public Image backFade;
	public GameObject popupPanel;
	public Text textCoinScore;

	public GameObject [] stars;

	void Awake () {
		textCoinScore.text = "0";

		popupPanel.transform.DOScale (new Vector3 (1f, 0f, 1f), 0f);
		backFade.DOFade (0f, 0f);
	}


	IEnumerator Start () {
		backFade.DOFade (1f, 0.5f).SetEase (Ease.Linear);
		yield return new WaitForSeconds (0.3f);
		popupPanel.transform.DOScaleY (1f, 0.2f).SetEase (Ease.OutBack);
	}

	IEnumerator CoinScore () {
		int count = 0;

		for (int i = 0; i < 10; i++) {
			count += Random.Range(1, 11);
			textCoinScore.text = count.ToString ();
			yield return null;
		}
	}


	public void ClosePanel () {
		popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
		backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
			Destroy (this.gameObject);
		});
	}

	public void ClosePanel (string sceneName) {
		popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
		backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
			PlayManager.Instance.SceneLoad (sceneName);
			Destroy (this.gameObject);
		});
	}


	public void GoToMainMenu() {
		
	}

	public void NextLevel () {
		
	}


}
