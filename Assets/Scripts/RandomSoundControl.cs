using UnityEngine;
using System.Collections;

public class RandomSoundControl : MonoBehaviour {

    public AudioClip[] audios;
    public AudioSource audio;
    public int fromTime = 1;
    public int toTime = 10;
    private bool isPlaying;
    private int waitTime;
    
    void Update()
    {
        if (!isPlaying && !audio.isPlaying)
        {
            isPlaying = true;
            StartCoroutine(InstantiateItem());
        }
    }

    IEnumerator InstantiateItem()
    {

        waitTime = Random.Range(1, 10);
        yield return new WaitForSeconds(waitTime);
        audio.clip = audios[Random.Range(0, audios.Length)];
        audio.Play();
        isPlaying = false;
    }
}
