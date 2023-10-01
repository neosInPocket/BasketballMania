using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
	[SerializeField] private Button _laserButton;
	[SerializeField] private Button _rotationButton;
	[SerializeField] private TMP_Text _coinsAmountText;
	[SerializeField] private TMP_Text _laserUpgradeAmount;
	[SerializeField] private TMP_Text _rotationUpgradeAmount;
	[SerializeField] private TMP_Text _coinsText;
	[SerializeField] private ErrorText _errorText;
	
	private void Start()
	{
		Refresh();
	}
	
	public void BuyRotationUpgrade()
	{
		var leftCoins = MainMenuController.Coins - 100;
		if (leftCoins < 0)
		{
			_errorText.Error();
			return;
		}
		MainMenuController.CurrentRotationSpeed++;
		MainMenuController.Coins -= 100;
		SaveLoad.Save();
		Refresh();
	}
	
	public void BuyLaserUpgrade()
	{
		var leftCoins = MainMenuController.Coins - 50;
		if (leftCoins < 0)
		{
			_errorText.Error();
			return;
		}
		MainMenuController.CurrentLaserUpgrade++;
		MainMenuController.Coins -= 50;
		SaveLoad.Save();
		Refresh();
	}
	
	public void Refresh()
	{
		_coinsText.text = MainMenuController.Coins.ToString();
		_coinsAmountText.text = "Your coins:";
		_laserUpgradeAmount.text = "Laser upgrade amount: " + MainMenuController.CurrentLaserUpgrade.ToString() + "/3";
		_rotationUpgradeAmount.text = "Rot. upgrade amount: " + MainMenuController.CurrentRotationSpeed.ToString() + "/3";
		
		if (MainMenuController.CurrentLaserUpgrade == 3)
		{
			_laserButton.interactable = false;
		}
		
		if (MainMenuController.CurrentRotationSpeed == 3)
		{
			_rotationButton.interactable = false;
		}
	}
}
