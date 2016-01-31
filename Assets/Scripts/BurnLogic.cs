#region References
using UnityEngine;
#endregion

public class BurnLogic : MonoBehaviour
{
	public GameObject Fire;
	public bool bad;
	public int score;
	public GameObject buttonsPoint;

	protected UIItemButtons buttons;
	private int FireStrength = 1;

	// Use this for initialization
	private void Start ()
	{
		if (buttons == null)
		{
			buttons = GameUI.GetItemButtons(buttonsPoint ? buttonsPoint : gameObject);
			buttons.confirm.onClick.AddListener(Confirm);
			buttons.reject.onClick.AddListener(Reject);
		}
	}

	// Update is called once per frame
	private void Update ()
	{
		if (LevelManager.instance.Score > 100 * LevelManager.instance.Level)
		{
			LevelManager.instance.Level += 0.5f;
			LevelManager.instance.GameLevel++;
			Debug.Log("level fucking up");
		}
	}

	private void burn ()
	{
        if (LevelManager.instance.IsGameOver)
        {
            Destroy(gameObject);
            return;
        }

        ActionSoundControl.instance.PlayBurnSound();

		LevelManager.instance.Score += bad ? -score : score;

		if (LevelManager.instance.Score < 0)
		{
			LevelManager.instance.Score = 0;
		}

		if (bad && LevelManager.instance.FireHp > 0f)
		{
			LevelManager.instance.FireHp -= 0.2f;
		}
		else if (LevelManager.instance.FireHp < 1f)
		{
			LevelManager.instance.FireHp += 0.05f;
		}

        Destroy(gameObject);
    }

	private void OnMouseDown ()
	{
		//ActionSoundControl.instance.PlayThrowSound();
		//Destroy(gameObject);
	}

	public void TimeEnded ()
	{
        if(LevelManager.instance.IsGameOver)
        {
            Destroy(gameObject);
            return;
        }

		if (bad)
		{
			burn();
		}
		else
		{
			ActionSoundControl.instance.PlayThrowSound();
		}
		Destroy(gameObject);
	}

	public void Confirm ()
	{
		burn();
		Destroy(gameObject);
	}

	public void Reject ()
	{
        if (!LevelManager.instance.IsGameOver)
			ActionSoundControl.instance.PlayThrowSound();
        
		Destroy(gameObject);
	}

	public void OnDestroy ()
	{
		if (buttons)
		{
			Destroy(buttons.gameObject);
			buttons = null;
		}
	}
}
