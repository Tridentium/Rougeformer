using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    bool hasBeenBought = false;
    bool isAblePurchase = false;
    public Image slotImage;
    public Transform inventoryStorage;
    public Transform shopItemHolder;
    public PlayerManagement player;
    public void buyItem()
    {
        if (!hasBeenBought)
        {
            for (int i = 0; i < inventoryStorage.childCount; i++)
            {
                if(inventoryStorage.GetChild(i).tag == "TempSlot")
                {
                    isAblePurchase = true;
                    break;
                }
            }
            if(player.currency < Mathf.FloorToInt(shopItemHolder.gameObject.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().weaponStrength * 100))
            {
                isAblePurchase = false;
            }
            if (isAblePurchase)
            {
                slotImage.color = Color.red;
                hasBeenBought = true;
                for (int i = 0; i < inventoryStorage.childCount; i++)
                {
                    if (inventoryStorage.GetChild(i).tag == "TempSlot")
                    {
                        Destroy(inventoryStorage.GetChild(i).gameObject);
                        GameObject item = shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject;
                        GameObject newItem = Instantiate(item, inventoryStorage);
                        newItem.transform.SetSiblingIndex(i);
                        hasBeenBought = true;
                        player.currency -= Mathf.FloorToInt(shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().weaponStrength * 100);
                        break;
                    }
                }
            }
            else
            {
                isAblePurchase = false;
            }
        }
    }
}
