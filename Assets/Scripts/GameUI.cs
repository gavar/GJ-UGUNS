#region References
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class GameUI : MonoBehaviour
{
	public static Slider GetTimeSlider (GameObject attachPoint)
	{
		if (instance == null) return null;

		var origin = instance.fireTime;
		if (origin == null) return null;

		var copy = Instantiate(origin);
		var copyGO = copy.gameObject;
		var follow = copyGO.AddComponent<UIFollow>();
		follow.point = attachPoint != null ? attachPoint.transform : null;
		copyGO.transform.SetParent(origin.transform.parent);
		copyGO.transform.localScale = origin.transform.localScale;
		follow.Update();
		copyGO.SetActive(true);
		return copy;
	}

	public static UIItemButtons GetItemButtons (GameObject attachPoint)
	{
		if (instance == null) return null;

		var origin = instance.itemButtons;
		if (origin == null) return null;

		var copy = Instantiate(origin);
		var copyGO = copy.gameObject;
		var follow = copyGO.AddComponent<UIFollow>();
		follow.point = attachPoint != null ? attachPoint.transform : null;
		copyGO.transform.SetParent(origin.transform.parent);
		copyGO.transform.localScale = origin.transform.localScale;
		follow.Update();
		copyGO.SetActive(true);
		return copy;
	}

	public static GameUI instance;

	public GameObject root;
	public Slider fireLevelBar;
	public Text scoreText;
	public Text levelText;

	public Slider fireTime;
	public UIItemButtons itemButtons;

	public void Awake ()
	{
		instance = this;
		if (fireTime) fireTime.gameObject.SetActive(false);
	}
	public void Start ()
	{
		LevelManager.instance.PropertyChanged += OnLevelManagerUpdate;
		Repaint();
	}

	private void Repaint ()
	{
		var data = LevelManager.instance;
		if (fireLevelBar) fireLevelBar.normalizedValue = data.FireHp;
		if (scoreText) scoreText.text = string.Format("{0:N0}", data.Score);
		if (levelText) levelText.text = string.Format("LEVEL: {0}", data.GameLevel);
	}

	private void OnLevelManagerUpdate (object sender, PropertyChangedEventArgs e) { Repaint(); }
}
