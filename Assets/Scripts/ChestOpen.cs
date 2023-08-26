using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestOpen : MonoBehaviour
{
    public BoxCollider2D Collider;
    public BoxCollider2D playerBox;
    public GameObject hoverText;
    public GameObject inventoryPanel;
    public ShopOpen open;
    public TierUpOpen open2;
    bool isPlayerThere = false;
    public bool inventoryOpen = false;
    // Update is called once per frame
    void Update()
    {
        if(Collider.IsTouching(playerBox))
        {
            isPlayerThere = true;
        }
        else
        {
            isPlayerThere = false;
        }
        if (isPlayerThere)
        {
            hoverText.SetActive(true);
        }
        else
        {
            hoverText.SetActive(false);
        }

        if(isPlayerThere && Input.GetKeyDown(KeyCode.F) && !inventoryOpen && !open.shopOpen && !open2.tierOpen){
            inventoryPanel.gameObject.SetActive(true);
            hoverText.SetActive(false);
            inventoryOpen = true;
        } else if (inventoryOpen && Input.GetKeyDown(KeyCode.Escape)) {
            hoverText.SetActive(true);
            inventoryPanel.gameObject.SetActive(false);
            inventoryOpen = false;
        }
    }
}
