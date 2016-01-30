#region References
using System;
using UnityEngine;
#endregion

[Serializable]
public class LevelManager : ReactiveObject
{
	public static readonly LevelManager instance = new LevelManager();

	[SerializeField] protected float level = 1f;
	[SerializeField] protected int score = 0;
	[SerializeField] protected int maxBadStuff = 5;
	[SerializeField] protected int badStuffCount = 0;

	public float Level { get { return level; } set { SetProperty(ref level, value, "Level"); } }
	public int Score { get { return score; } set { SetProperty(ref score, value, "Score"); } }
	public int MaxBadStuff { get { return score; } set { SetProperty(ref score, value, "MaxBadStuff"); } }
	public int BadStuffCount { get { return score; } set { SetProperty(ref score, value, "BadStuffCount"); } }
}
