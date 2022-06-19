using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public GameObject Title_BG;
    public void OnClick_1Stage_Btn()
    {
        Debug.Log("1Stage열림");
        SceneManager.LoadScene(1);
    }
    public void OnClick_2Stage_Btn()
    {
        Debug.Log("2Stage열림");
    }
    public void OnClick_3Stage_Btn()
    {
        Debug.Log("3Stage열림");
    }

    public void OnClick_4Stage_Btn()
    {
        Debug.Log("4Stage열림");
    }

    public void OnClickTabtoStart_Btn()
    {
        Title_BG.SetActive(false);
    }
}
