using UnityEngine;
using System.Collections;

public class ActionSoundControl : MonoBehaviour {

    public AudioClip[] throwAudios;
    public AudioClip[] burnAudios;
    public AudioClip[] buttonAudios;
    public AudioSource audio;
    private bool isPlaying;
    private int waitTime;

    public static ActionSoundControl instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayThrowSound()
    {
        playSound(getSound(throwAudios));
    }

    public void PlayBurnSound()
    {
        playSound(getSound(burnAudios));
    }

    public void PlayButtonSound()
    {
        playSound(getSound(buttonAudios));
    }
    
    private AudioClip getSound(AudioClip[] clips)
    {
        if(clips.Length == 0)
        {
            return null;
        }
        return clips[Random.Range(0, clips.Length - 1)];
    }

    private void playSound(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        audio.clip = clip;
        audio.Play();
    }
}
