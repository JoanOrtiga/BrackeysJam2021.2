using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public soundType soundT;
    private MusicManager m;
    void Start()
    {
        m = FindObjectOfType<MusicManager>();
        switch (soundT)
        {
            case soundType.SFX:
                GetComponent<Slider>().value = m.sfxVolume;
                break;
            case soundType.music:
                GetComponent<Slider>().value = m.musicVolume;
                break;
        }
    }

    public void SetVolume(float val)
    {
        m.ChangeVolume(val, soundT);
    }
}
