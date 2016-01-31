using UnityEngine;
using System.Collections;

public class BurnLogic : MonoBehaviour
{
    public GameObject Fire;
	public bool bad;
	public int score;

    private int FireStrength = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.Score > 100*LevelManager.instance.Level)
        {
            LevelManager.instance.Level += 0.5f;
            LevelManager.instance.GameLevel++;
            Debug.Log("level fucking up");
        }
    }

    public void burn()
    {

        ActionSoundControl.instance.PlayBurnSound();

		LevelManager.instance.Score += bad ? -score : score;

        if (LevelManager.instance.Score < 0)
        {
            LevelManager.instance.Score = 0;
        }

        if(bad && LevelManager.instance.FireHp > 0f)
        {
            LevelManager.instance.FireHp -= 0.2f;
        } else if (LevelManager.instance.FireHp < 1f)
        {
            LevelManager.instance.FireHp += 0.05f;
        }
    }


    void OnMouseDown()
    {
        ActionSoundControl.instance.PlayThrowSound();
        Destroy(gameObject);
    }
}
