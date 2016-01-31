#region References
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

	public void Awake () { instance = this; }

	public void Start ()
	{
		GameUI.instance.root.SetActive(false);
		btnPlay.onClick.AddListener(Play);
		btnMainMenu.onClick.AddListener(() => Setlayout(LayoutType.MainMenu));
		btnHowToPlay.onClick.AddListener(() => Setlayout(LayoutType.HowToPlay));
	}

	public void Setlayout (LayoutType layout)
	{
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
		Setlayout(LayoutType.Game);
		LevelManager.instance.StartGame();
	}

	public enum LayoutType
	{
		MainMenu,
		HowToPlay,
		Game,
		GameOver,
	}
}
