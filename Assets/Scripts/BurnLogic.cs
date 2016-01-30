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
        if (LevelManager.score > 100*LevelManager.level)
        {
            LevelManager.level += 0.5f;
            Debug.Log("level fucking up");
        }
    }

    public void burn()
    {
		LevelManager.score += bad ? -score : score;
    }


    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
