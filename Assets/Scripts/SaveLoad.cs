using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
	public static void Load()
	{
		MainMenuController.Coins = PlayerPrefs.GetInt("coins", 0);
		MainMenuController.CurrentLevel = PlayerPrefs.GetInt("currentLevel", 0);
		MainMenuController.CurrentSpeedUpgrade = PlayerPrefs.GetInt("CurrentSpeedUpgrade", 0);
		MainMenuController.CurrentLivesUpgrade = PlayerPrefs.GetInt("CurrentLivesUpgrade", 1);
		MainMenuController.IsFirstTime = PlayerPrefs.GetString("isFirstTime", "yes");
	}
	
	public static void Save()
	{
		PlayerPrefs.SetInt("coins", MainMenuController.Coins);
		PlayerPrefs.SetInt("currentLevel", MainMenuController.CurrentLevel);
		PlayerPrefs.SetInt("CurrentSpeedUpgrade", MainMenuController.CurrentSpeedUpgrade);
		PlayerPrefs.SetInt("CurrentLivesUpgrade", MainMenuController.CurrentLivesUpgrade);
		PlayerPrefs.SetString("isFirstTime", MainMenuController.IsFirstTime);
		PlayerPrefs.Save();
	}
}
