using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierUpOpen : MonoBehaviour
{
    public BoxCollider2D Collider;
    public BoxCollider2D playerBox;
    public GameObject hoverText;
    public GameObject inventoryPanel;
    public ChestOpen open;
    public ShopOpen open2;
    bool isPlayerThere = false;
    public bool tierOpen = false;
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
            hoverText.SetActive(true);
        }
        else
        {
            hoverText.SetActive(false);
        }

        if (isPlayerThere && Input.GetKeyDown(KeyCode.T) && !tierOpen && !open.inventoryOpen && !open2.shopOpen)
        {
            inventoryPanel.gameObject.SetActive(true);
            hoverText.SetActive(false);
            tierOpen = true;
        }
        else if (tierOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            TooltipSystem.Hide();
            hoverText.SetActive(true);
            inventoryPanel.gameObject.SetActive(false);
            tierOpen = false;
        }
    }
}
