using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolTimeUI : MonoBehaviour
{
    Image img_DashCoolUI;

    float maxTime = 7f;

    Player_Main player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player_Main)) as Player_Main;
        img_DashCoolUI = GetComponent<Image>();
        player.curDashCool = 0;
    }

    // Update is called once per frame
    void Update()
    {
        img_DashCoolUI.fillAmount = player.curDashCool / maxTime;
    }
}
