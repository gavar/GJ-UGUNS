using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class BackgroundMusicControl : MonoBehaviour
{

    public AudioMixerSnapshot acoustic;
    public AudioMixerSnapshot metal;
    public float bpm = 128;


    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    private bool isMetalPlaying = false;

    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;

    }

    void Update()
    {
        if(LevelManager.instance.Score < 500 && isMetalPlaying)
        {
            acoustic.TransitionTo(m_TransitionOut);
            isMetalPlaying = false;
        } else if (LevelManager.instance.Score >= 500 && !isMetalPlaying)
        {
            isMetalPlaying = true;
            metal.TransitionTo(m_TransitionIn);
        }
    }
}