using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioSource;
    private float musicVolume = 1f;
    public Sprite mute;
    public GameObject handle;
    public Sprite handleImage;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
        if (musicVolume == 0)
        {
            handle.GetComponent<Image>().sprite = mute;
        }
        if (musicVolume != 0)
        {
            handle.GetComponent<Image>().sprite = handleImage;
        }
    }
}
