using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public HotbarManager HotbarManager;
    public GameObject weaponManager;
    public bool isInArray = false;
    public void hotbarArrayChange()
    {
        foreach(GameObject objectInQuestion in HotbarManager.switchArray)
        {
            if(this.transform.parent.name == "ChestPanel")
            {
                if (objectInQuestion == weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject)
                {
                    this.gameObject.GetComponent<Image>().color = Color.white;
                    HotbarManager.switchArray.Remove(objectInQuestion);
                    isInArray = true;
                }
            }
            else
            {
                if (objectInQuestion == weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject)
                {
                    this.gameObject.GetComponent<Image>().color = Color.white;
                    HotbarManager.switchArray.Remove(objectInQuestion);
                    isInArray = true;
                }
            }
        }
        if (!isInArray) {
            if (this.transform.parent.name == "ChestPanel")
            {
                this.gameObject.GetComponent<Image>().color = Color.green;
                HotbarManager.switchArray.Add(weaponManager.transform.GetChild(this.transform.GetSiblingIndex() + 3).gameObject);
            }
            else
            {
                this.gameObject.GetComponent<Image>().color = Color.green;
                HotbarManager.switchArray.Add(weaponManager.transform.GetChild(this.transform.GetSiblingIndex()).gameObject);
            }

        }
        isInArray = false;
    }
}
