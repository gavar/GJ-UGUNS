using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireLevel : MonoBehaviour
{
    public GameObject[] FireEfects;

    GameObject currentEffectObject;
    ParticleSystem currentEffect;
    int currentIndex;

    void Start()
    {
        currentIndex = 0;
        currentEffectObject = (GameObject)Instantiate(FireEfects[currentIndex],
            transform.position, Quaternion.identity);
        currentEffectObject.transform.parent = transform;
        currentEffect = currentEffectObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        currentEffectObject.transform.localScale = new Vector3(1, 1, LevelManager.instance.Level);
    }
}
