using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class AudioManager : MonoBehaviour
{
    [Header("���� ���")]
    [SerializeField] Sound[] bgmSound;

    [Header("��� �÷��̾�")]
    [SerializeField] AudioSource bgmPlayer;
    void Start()
    {
        Play1StageBGM();
    }
    public void Play1StageBGM()
    {
        bgmPlayer.clip = bgmSound[0].clip;
        bgmPlayer.Play();
    }
}
