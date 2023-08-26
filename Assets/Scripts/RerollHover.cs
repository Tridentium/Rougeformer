using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RerollHover : MonoBehaviour
{
    public BoxCollider2D Collider;
    public BoxCollider2D playerBox;
    public TextMeshProUGUI hoverText;
    public PlayerManagement player;
    public bool isPlayerThere = false;
    // Update is called once per frame
    void Update()
    {
        if (Collider.IsTouching(playerBox))
        {
            isPlayerThere = true;
        }
        else
        {
            isPlayerThere = false;
        }
        if (isPlayerThere)
        {
            hoverText.enabled = true;
        }
        else
        {
            hoverText.enabled = false;
        }
        for (int i = 0; i < playerBox.gameObject.transform.GetChild(4).childCount; i++)
        {
            if (playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject.activeInHierarchy == true)
            {
                if (playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject.GetComponent<WeaponID>() != null)
                    hoverText.text = "Press R to reroll weapon for " + Mathf.FloorToInt(100 - playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject.GetComponent<WeaponID>().weaponStrength * 100).ToString() + " gold";
            }
        }

        if (isPlayerThere && Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < playerBox.gameObject.transform.GetChild(4).childCount; i++)
            {
                if (playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject.activeInHierarchy == true && player.currency >= Mathf.FloorToInt(100 - playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject.GetComponent<WeaponID>().weaponStrength * 100))
                {
                    player.currency -= Mathf.FloorToInt(100 - playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject.GetComponent<WeaponID>().weaponStrength * 100);
                    this.GetComponent<RerollScript>().RerollItem(playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject, playerBox.gameObject.transform.GetChild(4).GetChild(i).gameObject.GetComponent<WeaponID>());
                    break;
                }
            }
        }
    }
}
