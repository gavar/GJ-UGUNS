using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime = 5f;
    public Slider timeIndicator;
    public bool timeEnded = false;
    public BurnLogic burnLogic;
    public float procentage = 1f;

    private float time;
    private float initialTime;

    void Awake()
    {
        initialTime = startTime / LevelManager.level;
        time = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeEnded == true)
        {
           // Debug.Log("destroy object in timer");
            Destroy(gameObject);
			return;
        }

        time -= Time.deltaTime;

        procentage = (time / initialTime);

        timeIndicator.value = procentage;

        if (time <= 0 && burnLogic != null)
        {
            burnLogic.burn();
            timeEnded = true;
        }
    }
}
