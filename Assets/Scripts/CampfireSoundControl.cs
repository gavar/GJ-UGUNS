using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CampfireSoundControl : MonoBehaviour {


    public AudioMixerSnapshot low;
    public AudioMixerSnapshot high;
    public float bpm = 128;


    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    private bool isHigh = false;

    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;

    }

    void Update()
    {
        if (LevelManager.instance.FireHp < 0.6f && isHigh)
        {
            low.TransitionTo(m_TransitionOut);
            isHigh = false;
        }
        else if (LevelManager.instance.FireHp >= 0.6f && !isHigh)
        {
            isHigh = true;
            high.TransitionTo(m_TransitionIn);
        }
    }
}
