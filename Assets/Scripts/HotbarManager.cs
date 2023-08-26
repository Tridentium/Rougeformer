using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HotbarManager : MonoBehaviour
{
    public GameObject weaponManager;
    public GameObject[] weaponChildrenArray;
    public GameObject[] tempWeaponChildrenArray;
    public Transform chestSlotPanel;
    public List<GameObject> switchArray;
    public GameObject empty;
    bool weaponFound = false;
    int sibling1;
    int sibling2;
    public bool sibling1Chest = false;
    public bool sibling2Chest = false;
    // Update is called once per frame
    private void Start()
    {
        weaponChildrenArray = new GameObject[weaponManager.transform.childCount];
        tempWeaponChildrenArray = new GameObject[weaponManager.transform.childCount];
        for (int i = 0; i < weaponManager.transform.childCount; i++)
        {
            weaponChildrenArray[i] = weaponManager.transform.GetChild(i).gameObject;
            tempWeaponChildrenArray[i] = weaponManager.transform.GetChild(i).gameObject;
        }
    }
    void Update()
    {
        if (switchArray.Count >= 2){
            if (switchArray[0].transform.GetSiblingIndex() > 2)
            {
                sibling1Chest = true;
            }
            if (switchArray[1].transform.GetSiblingIndex() > 2)
            {
                sibling2Chest = true;
            }
            sibling1 = switchArray[0].transform.GetSiblingIndex();
            sibling2 = switchArray[1].transform.GetSiblingIndex();
            switchArray[0].transform.SetSiblingIndex(sibling2);
            switchArray[1].transform.SetSiblingIndex(sibling1);
            if (sibling1Chest)
            {
                chestSlotPanel.GetChild(sibling1 - 3).GetComponent<Image>().color = Color.white;
            }
            else
            {
                this.transform.GetChild(sibling1).GetComponent<Image>().color = Color.white;
            }
            if (sibling2Chest)
            {
                chestSlotPanel.GetChild(sibling2 - 3).GetComponent<Image>().color = Color.white;
            }
            else
            {
                this.transform.GetChild(sibling2).GetComponent<Image>().color = Color.white;
            }
            switchArray.Clear();
            sibling1Chest = false;
            sibling2Chest = false;
        }
        weaponChildrenArray = new GameObject[weaponManager.transform.childCount];
        for (int i = 0; i < weaponManager.transform.childCount; i++)
        {
            weaponChildrenArray[i] = weaponManager.transform.GetChild(i).gameObject;
        }
        if(weaponChildrenArray.Length < 3)
        {
            for(int i = 0; i < tempWeaponChildrenArray.Length; i++)
            {
                foreach(GameObject oldWeapon in weaponChildrenArray)
                {
                    weaponFound = false;
                    if (oldWeapon == tempWeaponChildrenArray[i])
                    {
                        weaponFound = true;
                    }
                }
                if (weaponFound)
                {
                    GameObject temp = Instantiate(empty, weaponManager.transform);
                    temp.transform.SetSiblingIndex(i-1);
                }
                weaponFound = false;
            }
        }
        tempWeaponChildrenArray = weaponChildrenArray;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject Go = this.transform.GetChild(i).gameObject;
            Image slotImage = Go.transform.GetChild(0).GetComponent<Image>();
            if(weaponManager.transform.childCount >= i + 1)
            {
                slotImage.enabled = true;
                if(weaponManager.transform.GetChild(i).gameObject.tag != "TempSlot")
                {
                    slotImage.enabled = true;
                    slotImage.sprite = weaponManager.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    slotImage.enabled = false;
                }

            }
            else
            {
                slotImage.enabled = false;
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            for (int i = 0; i < chestSlotPanel.childCount - 2; i++)
            {
                GameObject Go = chestSlotPanel.GetChild(i).gameObject;
                Image slotImage = Go.transform.GetChild(0).GetComponent<Image>();
                if (weaponManager.transform.childCount >= i + 4)
                {
                    slotImage.enabled = true;
                    if (weaponManager.transform.GetChild(i + 3).gameObject.tag != "TempSlot")
                    {
                        slotImage.enabled = true;
                        slotImage.sprite = weaponManager.transform.GetChild(i + 3).GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        slotImage.enabled = false;
                    }

                }
                else
                {
                    slotImage.enabled = false;
                }
            }
        }
    }


}
