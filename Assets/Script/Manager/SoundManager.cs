using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instace;

    public Dictionary<string, AudioClip> audioclipPairs = new Dictionary<string, AudioClip>();
    public List<AudioClip> audioClips = new List<AudioClip>();
    void Awake() 
    {
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(instace);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        foreach(var clip in audioClips) 
        {
            audioclipPairs.Add(clip.name, clip);
            //AudioClip a = audioclipPairs["�ӱ��"];
        }
    }

    public void SFXPlay(string sfxName)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = audioclipPairs[sfxName];
        audioSource.Play();

        Destroy(go, audioclipPairs[sfxName].length);
    }
}
