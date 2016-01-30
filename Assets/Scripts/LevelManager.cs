public class LevelManager : ReactiveObject
{
	public static readonly LevelManager instance = new LevelManager();

	protected float level = 1f;
	protected int score = 0;
	protected int maxBadStuff = 5;
	protected int badStuffCount = 0;

	public float Level { get { return level; } set { SetProperty(ref level, value, "Level"); } }
	public int Score { get { return score; } set { SetProperty(ref score, value, "Score"); } }
	public int MaxBadStuff { get { return score; } set { SetProperty(ref score, value, "MaxBadStuff"); } }
	public int BadStuffCount { get { return score; } set { SetProperty(ref score, value, "BadStuffCount"); } }
}
