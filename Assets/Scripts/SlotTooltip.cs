using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotTooltip : MonoBehaviour
{
    public GameObject weaponManager;
    public GameObject shopItemHolder;
    public TooltipTrigger trigger;
    public Color tooltipColour;
    private void Update()
    {

        if (this.transform.parent.name == "ChestPanel")
        {
            if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).tag != "TempSlot")
            {
                trigger.header = weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().weaponName;
                trigger.content = weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().weaponDesc;
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 0)
                {
                    tooltipColour = new Color(1, 1, 1, 0.7843137f);
                }
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 1)
                {
                    tooltipColour = new Color(1, 1, 1, 0.7843137f);
                }
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 2)
                {
                    tooltipColour = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
                }
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 3)
                {
                    tooltipColour = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
                }
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 4)
                {
                    tooltipColour = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
                }
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 5)
                {
                    tooltipColour = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
                }
            }
            else
            {
                trigger.header = "Empty Slot";
                trigger.content = "Contrary to popular opinon, the void of an empty slot actually allows for infinite possibilities";
                tooltipColour = new Color(1, 1, 1, 0.7843137f);
            }
        } 
        else if (this.transform.parent.name == "ShopPanel")
        {
            if (shopItemHolder.transform.GetChild(this.transform.GetSiblingIndex()).tag != "TempSlot")
            {
                trigger.header = shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().weaponName;
                trigger.content = shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().weaponDesc + @"
" + "Price: " + Mathf.FloorToInt(shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().weaponStrength * 100);
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 0)
                {
                    tooltipColour = new Color(1, 1, 1, 0.7843137f);
                }
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 1)
                {
                    tooltipColour = new Color(1, 1, 1, 0.7843137f);
                }
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 2)
                {
                    tooltipColour = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
                }
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 3)
                {
                    tooltipColour = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
                }
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 4)
                {
                    tooltipColour = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
                }
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 5)
                {
                    tooltipColour = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
                }
            }
            else
            {
                trigger.header = "Empty Slot";
                trigger.content = "Contrary to popular opinon, the void of an empty slot actually allows for infinite possibilities";
                tooltipColour = new Color(1, 1, 1, 0.7843137f);
            }
        }
        else
        {
            if(weaponManager.transform.childCount > 0)
            {
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).tag != "TempSlot")
                {
                    trigger.header = weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().weaponName;
                    trigger.content = weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().weaponDesc;
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 0)
                    {
                        tooltipColour = new Color(1, 1, 1, 0.7843137f);
                    }
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 1)
                    {
                        tooltipColour = new Color(1, 1, 1, 0.7843137f);
                    }
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 2)
                    {
                        tooltipColour = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
                    }
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 3)
                    {
                        tooltipColour = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
                    }
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 4)
                    {
                        tooltipColour = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
                    }
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 5)
                    {
                        tooltipColour = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
                    }
                }
                else
                {
                    trigger.header = "Empty Slot";
                    trigger.content = "Contrary to popular opinon, the void of an empty slot actually allows for infinite possibilities";
                    tooltipColour = new Color(1, 1, 1, 0.7843137f);
                }
            }
        }
        }
}
