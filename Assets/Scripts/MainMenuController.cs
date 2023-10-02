using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	[SerializeField] private Camera _mainCamera;
	[SerializeField] private FadeScreen _fadeScreen; 
	[SerializeField] private ShopScreen _shopScreen;
	[SerializeField] private GameController _gameController; 
	[SerializeField] private MainMenuScreen _menuScreen;
	
	public static int CurrentLevel { get; set; } = 0;
	public static int Coins { get; set; } = 0;
	public static int CurrentSpeedUpgrade { get; set; } = 0;
	public static int CurrentLivesUpgrade { get; set; } = 1;
	public static string IsFirstTime { get; set; } = "yes";
	
	public void Initialize()
	{
		SaveLoad.Load();
		_menuScreen.gameObject.SetActive(true);
		GameController.PlanetsSprites = Resources.LoadAll<Sprite>("");
		_mainCamera.cullingMask = LayerMask.GetMask("TransparentFX", "Ignore Raycast", "Water", "UI", "Rig");
	}
	
	public void GetToGame()
	{
		_fadeScreen.OnFadeEnd += LoadGame;
	}
	
	#region changing screens
	public void GoToShop()
	{
		_fadeScreen.OnFadeEnd += LoadShopScreen;
	}
	
	public void GoToMainMenu()
	{
		_fadeScreen.OnFadeEnd += LoadMenuScreen;
	}
	
	public void LoadShopScreen()
	{
		_fadeScreen.OnFadeEnd -= LoadShopScreen;
		_menuScreen.gameObject.SetActive(false);
		_shopScreen.gameObject.SetActive(true);
		_shopScreen.Refresh();
	}
	
	public void LoadMenuScreen()
	{
		_fadeScreen.OnFadeEnd -= LoadMenuScreen;
		_menuScreen.gameObject.SetActive(true);
		_shopScreen.gameObject.SetActive(false);
	}
	
	#endregion
	public void LoadGame()
	{
		_fadeScreen.OnFadeEnd -= LoadGame;
		_menuScreen.gameObject.SetActive(false);
		_gameController.Initialize();
		_mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig");
	}
	
	public void Save()
	{
		SaveLoad.Save();
	}
	
	public void ClearProgress()
	{
		MainMenuController.Coins = 100;
		MainMenuController.CurrentLevel = 1;
		MainMenuController.CurrentSpeedUpgrade = 0;
		MainMenuController.CurrentLivesUpgrade = 1;
		MainMenuController.IsFirstTime = "yes";
		SaveLoad.Save();
	}
	
	public void Exit()
	{
		Application.Quit();
	}
}
