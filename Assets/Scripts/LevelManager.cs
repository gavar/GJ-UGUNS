﻿#region References
using System;
using UnityEngine;
#endregion

[Serializable]
public class LevelManager : ReactiveObject
{
	public static readonly LevelManager instance = new LevelManager();

	[SerializeField] protected float level = 1f;
	[SerializeField] protected float fireHp = 0.5f;
	[SerializeField] protected int score = 0;
	[SerializeField] protected int gameLevel = 1;
	[SerializeField] protected int maxLevel = 10;
	[SerializeField] protected bool gameStarted = false;

	public float Level { get { return level; } set { SetProperty(ref level, value, "Level"); } }
	public float FireHp
	{
		get { return fireHp; }
		set
		{
			if (!SetProperty(ref fireHp, value, "FireHp")) return;
			if (fireHp <= 0f) UIMenu.instance.GameOver();
		}
	}
	public int GameLevel { get { return gameLevel; } set { SetProperty(ref gameLevel, value, "GameLevel"); } }
	public int Score { get { return score; } set { SetProperty(ref score, value, "Score"); } }
	public int MaxLevel { get { return maxLevel; } set { SetProperty(ref maxLevel, value, "MaxLevel"); } }
	public bool GameStarted { get { return gameStarted; } set { SetProperty(ref gameStarted, value, "GameStarted"); } }
}
