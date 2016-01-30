﻿#region References
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class GameUI : MonoBehaviour
{
	public static Slider GetTimeSlider (GameObject attachPoint)
	{
		if (instance == null) return null;
		if (instance.fireTime == null) return null;
		var copy = Instantiate(instance.fireTime);
		copy.gameObject.SetActive(true);
		var follow = copy.gameObject.AddComponent<UIFollow>();
		follow.point = attachPoint.transform;
		copy.gameObject.SetActive(true);
		return copy;
	}

	public static GameUI instance;

	public GameObject root;
	public Slider fireLevelBar;
	public Text scoreText;
	public Text levelText;

	public Slider fireTime;

	public void Awake () { instance = this; }
	public void Start ()
	{
		LevelManager.instance.PropertyChanged += OnLevelManagerUpdate;
		Repaint();
	}

	private void Repaint ()
	{
		var data = LevelManager.instance;
		if (fireLevelBar) fireLevelBar.normalizedValue = data.Level;
		if (scoreText) scoreText.text = string.Format("{0:N0}", data.Score);
		if (levelText) levelText.text = string.Format("LEVEL: {0}", data.GameLevel);
	}

	private void OnLevelManagerUpdate (object sender, PropertyChangedEventArgs e) { Repaint(); }
}
