using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireLevel : MonoBehaviour
{
    public GameObject[] FireEfects;

    GameObject effectLocation;
    GameObject currentEffectObject;
    ParticleSystem currentEffect;
    int currentIndex;
    public int testIndex;

    void Start()
    {
        currentIndex = 0;
        effectLocation = GameObject.Find("/Campfire/FireEffect");
        UpdateFireEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEffectObject != null)
        {
            currentEffectObject.transform.localScale = new Vector3(1, 1, LevelManager.instance.Level);
        }
        //if(LevelManager.level>= currentIndex + 1)
        if (testIndex != currentIndex)
        {
            currentIndex = testIndex;
            //currentIndex++;
            UpdateFireEffect();
        }
    }

    private void UpdateFireEffect()
    {
        if(currentEffectObject != null)
        {
            Destroy(currentEffectObject);
        }

        currentEffectObject = (GameObject)Instantiate(FireEfects[currentIndex],
            effectLocation.transform.position, Quaternion.identity);
        currentEffectObject.transform.parent = effectLocation.transform;
        currentEffect = currentEffectObject.GetComponent<ParticleSystem>();
    }
}
