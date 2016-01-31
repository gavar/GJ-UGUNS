#region References
using System;
using UnityEngine;
#endregion

[Serializable]
public class LevelManager : ReactiveObject
{
	public static readonly LevelManager instance = new LevelManager();

	[SerializeField] protected float level = 1f;
	[SerializeField] protected float fireHP = 0.5f;
	[SerializeField] protected int score = 0;
	[SerializeField] protected int gameLevel = 1;
	[SerializeField] protected int maxLevel = 10;
	[SerializeField] protected bool gameStarted = false;
    [SerializeField] protected bool isGameOver = false;

    public float Level { get { return level; } set { SetProperty(ref level, value, "Level"); } }
	public float FireHp
	{
		get { return fireHP; }
		set
		{
			if (!SetProperty(ref fireHP, value, "FireHP")) return;
			if (fireHP <= 0f) GameOver();
		}
	}
	public int GameLevel { get { return gameLevel; } set { SetProperty(ref gameLevel, value, "GameLevel"); } }
	public int Score { get { return score; } set { SetProperty(ref score, value, "Score"); } }
	public int MaxLevel { get { return maxLevel; } set { SetProperty(ref maxLevel, value, "MaxLevel"); } }
	public bool GameStarted { get { return gameStarted; } protected set { SetProperty(ref gameStarted, value, "GameStarted"); } }
    public bool IsGameOver { get { return isGameOver; } protected set { SetProperty(ref isGameOver, value, "IsGameOver"); } }

    public void StartGame ()
	{
		score = 0;
		level = 1f;
		fireHP = .5f;
		gameLevel = 1;
		GameStarted = true;
        IsGameOver = false;
	}

	public void GameOver ()
	{
		GameStarted = false;
        IsGameOver = true;
		UIMenu.instance.GameOver();
	}
}
