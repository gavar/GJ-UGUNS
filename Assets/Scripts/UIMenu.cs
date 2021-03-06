﻿#region References
using UnityEngine;
using UnityEngine.UI;
#endregion

public class UIMenu : MonoBehaviour
{
	public static UIMenu instance;

	public Button btnPlay;
	public Button btnHowToPlay;
	public Button btnMainMenu;

	public GameObject rootLayout;
	public GameObject gameOverLayout;
	public GameObject howToPlayLayout;
	public GameObject mainMenuLayout;
	public GameObject toMainMenuLayout;
	public Text gameOverScore;
	protected LayoutType prevLayout;

	public void Awake () { instance = this; }

	public void Start ()
	{
		GameUI.instance.root.SetActive(false);
		btnPlay.onClick.AddListener(Play);
		btnMainMenu.onClick.AddListener(MainMenu);
		btnHowToPlay.onClick.AddListener(HowToPlay);
	}

	public void Setlayout (LayoutType layout)
	{
		if (prevLayout == LayoutType.GameOver)
			CameraMovement.instance.MoveToInitial();

		prevLayout = layout;
		rootLayout.SetActive(layout != LayoutType.Game);
		gameOverLayout.SetActive(layout == LayoutType.GameOver);
		mainMenuLayout.SetActive(layout == LayoutType.MainMenu);
		howToPlayLayout.SetActive(layout == LayoutType.HowToPlay);
		toMainMenuLayout.SetActive(layout != LayoutType.MainMenu);
		GameUI.instance.root.SetActive(layout == LayoutType.Game);
	}

	public void Play ()
	{
		Debug.Log("PLAY");
        ActionSoundControl.instance.PlayButtonSound();
		Setlayout(LayoutType.Game);
		LevelManager.instance.StartGame();
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().MoveToTarget();
	}

    public void MainMenu()
    {
        ActionSoundControl.instance.PlayButtonSound();
        Setlayout(LayoutType.MainMenu);
    }

    public void HowToPlay()
    {
        ActionSoundControl.instance.PlayButtonSound();
        Setlayout(LayoutType.HowToPlay);
    }

	public void GameOver ()
	{
        Setlayout(LayoutType.GameOver);
		if (gameOverScore) gameOverScore.text = LevelManager.instance.Score.ToString("N0");
	}

	public enum LayoutType
	{
		MainMenu,
		HowToPlay,
		Game,
		GameOver,
	}
}
