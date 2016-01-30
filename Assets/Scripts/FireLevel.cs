using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireLevel : MonoBehaviour
{
    public GameObject[] FireEfects;

    GameObject fireParticles;
    GameObject currentEffectObject;
    ParticleSystem currentEffect;
    int currentIndex;
    public int testIndex;

    void Start()
    {
        currentIndex = 0;
        fireParticles = GameObject.Find("/Campfire/Ground_Fire_Small");
        //UpdateFireEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireParticles != null &&
            fireParticles.transform.localScale.z != LevelManager.instance.Level)
        {
            Debug.Log("Fire up");
            fireParticles.transform.localScale = 
                new Vector3(LevelManager.instance.Level, 
                LevelManager.instance.Level, LevelManager.instance.Level);
        }
        ////if(LevelManager.level>= currentIndex + 1)
        //if (testIndex != currentIndex)
        //{
        //    currentIndex = testIndex;
        //    //currentIndex++;
        //    UpdateFireEffect();
        //}
    }

    private void UpdateFireEffect()
    {
        if(currentEffectObject != null)
        {
            Destroy(currentEffectObject);
        }

        currentEffectObject = (GameObject)Instantiate(FireEfects[currentIndex],
            fireParticles.transform.position, Quaternion.identity);
        currentEffectObject.transform.parent = fireParticles.transform;
        currentEffect = currentEffectObject.GetComponent<ParticleSystem>();
    }
}
