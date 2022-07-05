using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{

    public static BtnManager instace;
    public GameObject GameClear;
    public GameObject GameOver;

    private int SceneNum;
    void Awake()
    {
        instace = this;    
    }
    void Start()
    {
        Time.timeScale = 1;
    }
    public void OnClickMenu_TabtoStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClick_1Stage_Btn()
    {
        SceneNum = 1;
        StartCoroutine(Stage_Move());
    }

    public void OnClick_2Stage_Btn()
    {
        SceneNum = 2;
        StartCoroutine(Stage_Move());
    }
    public void OnClick_4Stage_Btn()
    {
        SceneNum = 4;
        StartCoroutine(Stage_Move());
    }
    public void OnClick_Exit()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClick_Stage1_GameOver_Retry()
    {
        SceneManager.LoadScene(2);
    }
    public void OnClick_Stage2_GameOver_Retry()
    {
        SceneManager.LoadScene(3);
    }
    public void OnClick_Stage4_GameOver_Retry()
    {
        SceneManager.LoadScene(4);
    }
    public void OnClick_Stage1_GameClear_NextStage()
    {
        SceneManager.LoadScene(3);
    }
    public void OnClick_Stage2_GameClear_NextStage()
    {
        SceneManager.LoadScene(4);
    }
    IEnumerator Stage_Move()
    {
        yield return new WaitForSeconds(0.5f);

        switch (SceneNum)
        {
            case 1:
                Debug.Log("1Stage열림");
                SceneManager.LoadScene(2);
                break;
            case 2:
                Debug.Log("2Stage열림");
                SceneManager.LoadScene(3);
                break;
            case 4:
                Debug.Log("4Stage열림");
                SceneManager.LoadScene(4);
                break;

        }
    }
}
