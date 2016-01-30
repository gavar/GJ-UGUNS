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
            Debug.Log("level fucking up");
        }
    }

    public void burn()
    {
		LevelManager.instance.Score += bad ? -score : score;
    }


    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
