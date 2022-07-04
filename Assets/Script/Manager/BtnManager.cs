using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public GameObject Title_BG;
    public GameObject Setting_PopUp;

    private int SceneNum;
    void Start()
    {
        Time.timeScale = 1;    
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
    public void OnClick_3Stage_Btn()
    {
        SceneNum = 3;
        StartCoroutine(Stage_Move());
    }

    public void OnClick_4Stage_Btn()
    {
        SceneNum = 4;
        StartCoroutine(Stage_Move());
    }

    public void OnClickTabtoStart_Btn()
    {
        Title_BG.SetActive(false);
    }
    public void OnClickSetting_Btn()
    {
        Time.timeScale = 0;
        Setting_PopUp.SetActive(true);
    }
    public void OnClickReturn_Btn()
    {
        Time.timeScale = 1;
        Setting_PopUp.SetActive(false);
    }
    public void OnClickQuit_Btn()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator Stage_Move()
    {
        yield return new WaitForSeconds(0.5f);

        switch (SceneNum)
        {
            case 1:
                Debug.Log("1Stage열림");
                SceneManager.LoadScene(1);
                break;

            case 2:
                Debug.Log("2Stage열림");
                SceneManager.LoadScene(2);
                break;

            case 3:
                Debug.Log("3Stage열림");
                SceneManager.LoadScene(3);
                break;

            case 4:
                Debug.Log("4Stage열림");
                SceneManager.LoadScene(4);
                break;

        }
    }
}
