using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoBehaviour
{
    Image img_PlayerHpBar;

    float maxHp = 100;

    Player_Main player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player_Main)) as Player_Main;
        img_PlayerHpBar = GetComponent<Image>();
        player.Hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        img_PlayerHpBar.fillAmount = (float)player.Hp / maxHp;
    }
}
