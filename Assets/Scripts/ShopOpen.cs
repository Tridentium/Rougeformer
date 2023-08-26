using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    public BoxCollider2D Collider;
    public BoxCollider2D playerBox;
    public GameObject hoverText;
    public GameObject inventoryPanel;
    public ChestOpen open;
    public TierUpOpen open2;
    bool isPlayerThere = false;
    public bool shopOpen = false;
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

        if (isPlayerThere && Input.GetKeyDown(KeyCode.E) && !shopOpen && !open.inventoryOpen && !open2.tierOpen)
        {
            inventoryPanel.gameObject.SetActive(true);
            hoverText.SetActive(false);
            shopOpen = true;
        }
        else if (shopOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            TooltipSystem.Hide();
            hoverText.SetActive(true);
            inventoryPanel.gameObject.SetActive(false);
            shopOpen = false;
        }
    }
}
