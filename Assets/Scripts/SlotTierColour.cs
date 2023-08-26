using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotTierColour : MonoBehaviour
{
    public GameObject weaponManager;
    public GameObject shopItemHolder;

    // Update is called once per frame
    private void Update()
    {

        if (this.transform.parent.name == "ChestPanel")
        {
            if(weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.tag != "TempSlot")
            {
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 1)
                    this.GetComponent<Image>().color = new Color(1, 1, 1, 0.7843137f);
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 2)
                    this.GetComponent<Image>().color = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 3)
                    this.GetComponent<Image>().color = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 4)
                    this.GetComponent<Image>().color = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
                if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject.GetComponent<WeaponID>().tier == 5)
                    this.GetComponent<Image>().color = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
            }
        }
        else if (this.transform.parent.name == "ShopPanel")
        {
            if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.tag != "TempSlot")
            {
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 1)
                    this.GetComponent<Image>().color = new Color(1, 1, 1, 0.7843137f);
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 2)
                    this.GetComponent<Image>().color = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 3)
                    this.GetComponent<Image>().color = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 4)
                    this.GetComponent<Image>().color = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
                if (shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - this.transform.GetSiblingIndex()].gameObject.GetComponent<WeaponID>().tier == 5)
                    this.GetComponent<Image>().color = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
            }
        }
        else
        {
            if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.tag != "TempSlot")
            {
                if (weaponManager.transform.childCount > 0)
                {
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 1)
                        this.GetComponent<Image>().color = new Color(1, 1, 1, 0.7843137f);
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 2)
                        this.GetComponent<Image>().color = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 3)
                        this.GetComponent<Image>().color = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 4)
                        this.GetComponent<Image>().color = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
                    if (weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject.GetComponent<WeaponID>().tier == 5)
                        this.GetComponent<Image>().color = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
                }
            }
        }
    }
}
