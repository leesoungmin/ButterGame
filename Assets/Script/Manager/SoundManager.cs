using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //private void Start()
    //{
    //    foreach (var clip in audioClips)
    //    {
    //        audioclipPairs.Add(clip.name, clip);
    //        // AudioClip a = audioclipPairs["¾Ó±â¸ð"];
    //    }
    //}
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }
}
