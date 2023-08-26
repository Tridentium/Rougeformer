using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TierUpScript : MonoBehaviour
{
    public int[][] partsNeeded;
    public int tier;
    public WeaponManager manager;
    public TextMeshProUGUI partsNeededText;
    public PlayerManagement playerManagement;
    public TextMeshProUGUI partsHad;
    public Button button;
    public RerollScript rerollScript;
    Color usualColour;
    Color redColour;
    int currentSelectedWeapon;
    int pastSelectedWeapon = 2323;
    private void Start()
    {
        partsNeeded = new int[3][];
        usualColour = new Color(0.9622642f, 0.8439376f, 0.3495016f, 0.7921569f);
        redColour = new Color(1, 0.2521928f, 0.06132078f, 0.7921569f);
    }
    private void Update()
    {   if(manager.transform.GetChild(manager.selectedWeapon).gameObject.tag != "TempSlot")
        {
            tier = manager.transform.GetChild(manager.selectedWeapon).gameObject.GetComponent<WeaponID>().tier;
            currentSelectedWeapon = manager.selectedWeapon;
            if (tier > 0 && tier < 5 && currentSelectedWeapon != pastSelectedWeapon)
            {
                pastSelectedWeapon = manager.selectedWeapon;
                partsNeeded[0] = new int[2];
                partsNeeded[0][0] = Random.Range((tier - 1) * 3, (tier * 3));
                partsNeeded[0][1] = Random.Range(5, 15);

                partsNeeded[1] = new int[2];
                partsNeeded[1][0] = Random.Range(0, (tier * 3));
                partsNeeded[1][1] = Random.Range(5, 15);

                partsNeeded[2] = new int[2];
                partsNeeded[2][0] = Random.Range(0, (tier * 3));
                partsNeeded[2][1] = Random.Range(5, 15);

                string firstPartName = "";
                string secondPartName = "";
                string thirdPartName = "";

                if (partsNeeded[0][0] == 0)
                    firstPartName = "leaves";
                if (partsNeeded[0][0] == 1)
                    firstPartName = "sticks";
                if (partsNeeded[0][0] == 2)
                    firstPartName = "dirt";
                if (partsNeeded[0][0] == 3)
                    firstPartName = "rocks";
                if (partsNeeded[0][0] == 4)
                    firstPartName = "wooden screws";
                if (partsNeeded[0][0] == 5)
                    firstPartName = "metal shards";
                if (partsNeeded[0][0] == 6)
                    firstPartName = "metal components";
                if (partsNeeded[0][0] == 7)
                    firstPartName = "copper wire";
                if (partsNeeded[0][0] == 8)
                    firstPartName = "broken machinery";
                if (partsNeeded[0][0] == 9)
                    firstPartName = "spare parts";
                if (partsNeeded[0][0] == 10)
                    firstPartName = "essence of alcheron";
                if (partsNeeded[0][0] == 11)
                    firstPartName = "parts of the earth's molten core";
                if (partsNeeded[0][0] == 12)
                    firstPartName = "alcheron crystals";
                if (partsNeeded[0][0] == 13)
                    firstPartName = "solar spirits";
                if (partsNeeded[0][0] == 14)
                    firstPartName = "gaia's gists";

                if (partsNeeded[1][0] == 0)
                    secondPartName = "leaves";
                if (partsNeeded[1][0] == 1)
                    secondPartName = "sticks";
                if (partsNeeded[1][0] == 2)
                    secondPartName = "dirt";
                if (partsNeeded[1][0] == 3)
                    secondPartName = "rocks";
                if (partsNeeded[1][0] == 4)
                    secondPartName = "wooden screws";
                if (partsNeeded[1][0] == 5)
                    secondPartName = "metal shards";
                if (partsNeeded[1][0] == 6)
                    secondPartName = "metal components";
                if (partsNeeded[1][0] == 7)
                    secondPartName = "copper wire";
                if (partsNeeded[1][0] == 8)
                    secondPartName = "broken machinery";
                if (partsNeeded[1][0] == 9)
                    secondPartName = "spare parts";
                if (partsNeeded[1][0] == 10)
                    secondPartName = "essence of alcheron";
                if (partsNeeded[1][0] == 11)
                    secondPartName = "parts of the earth's molten core";
                if (partsNeeded[1][0] == 12)
                    secondPartName = "alcheron crystals";
                if (partsNeeded[1][0] == 13)
                    secondPartName = "solar spirits";
                if (partsNeeded[1][0] == 14)
                    secondPartName = "gaia's gists";

                if (partsNeeded[2][0] == 0)
                    thirdPartName = "leaves";
                if (partsNeeded[2][0] == 1)
                    thirdPartName = "sticks";
                if (partsNeeded[2][0] == 2)
                    thirdPartName = "dirt";
                if (partsNeeded[2][0] == 3)
                    thirdPartName = "rocks";
                if (partsNeeded[2][0] == 4)
                    thirdPartName = "wooden screws";
                if (partsNeeded[2][0] == 5)
                    thirdPartName = "metal shards";
                if (partsNeeded[2][0] == 6)
                    thirdPartName = "metal components";
                if (partsNeeded[2][0] == 7)
                    thirdPartName = "copper wire";
                if (partsNeeded[2][0] == 8)
                    thirdPartName = "broken machinery";
                if (partsNeeded[2][0] == 9)
                    thirdPartName = "spare parts";
                if (partsNeeded[2][0] == 10)
                    thirdPartName = "essence of alcheron";
                if (partsNeeded[2][0] == 11)
                    thirdPartName = "parts of the earth's molten core";
                if (partsNeeded[2][0] == 12)
                    thirdPartName = "alcheron crystals";
                if (partsNeeded[2][0] == 13)
                    thirdPartName = "solar spirits";
                if (partsNeeded[2][0] == 14)
                    thirdPartName = "gaia's gists";

                partsNeededText.text = partsNeeded[0][1] + " " + firstPartName + ", " + partsNeeded[1][1] + " " + secondPartName + ", " + partsNeeded[2][1] + " " + thirdPartName;
                partsHad.text = playerManagement.partsStorage[partsNeeded[0][0]] + " " + firstPartName + ", " + playerManagement.partsStorage[partsNeeded[1][0]] + " " + secondPartName + ", " + playerManagement.partsStorage[partsNeeded[2][0]] + " " + thirdPartName;
                if ((playerManagement.partsStorage[partsNeeded[0][0]] > partsNeeded[0][1] && playerManagement.partsStorage[partsNeeded[1][0]] > partsNeeded[1][1] && playerManagement.partsStorage[partsNeeded[2][0]] > partsNeeded[2][1]))
                {
                    button.gameObject.GetComponent<Image>().color = usualColour;
                }
                else
                {
                    button.gameObject.GetComponent<Image>().color = redColour;
                }
            }
            else if (currentSelectedWeapon != pastSelectedWeapon)
            {
                pastSelectedWeapon = manager.selectedWeapon;
                partsNeededText.text = "This weapon is not valid for tiering up";
                partsHad.text = "This weapon is not valid for tiering up";
                button.gameObject.GetComponent<Image>().color = redColour;
            }
        }
        else
        {
            pastSelectedWeapon = manager.selectedWeapon;
            button.gameObject.GetComponent<Image>().color = redColour;
            partsNeededText.text = "There is no weapon currently selected";
            partsHad.text = "There is no weapon currently selected";
        }
        
    }

    public void tierUpWeapon()
    {
        if (button.gameObject.GetComponent<Image>().color == usualColour)
        {
            playerManagement.partsStorage[partsNeeded[0][0]] -= partsNeeded[0][1];
            playerManagement.partsStorage[partsNeeded[1][0]] -= partsNeeded[1][1];
            playerManagement.partsStorage[partsNeeded[2][0]] -= partsNeeded[2][1];
            manager.transform.GetChild(manager.selectedWeapon).gameObject.GetComponent<WeaponID>().tier += 1;
            rerollScript.RerollItem(manager.transform.GetChild(manager.selectedWeapon).gameObject, manager.transform.GetChild(manager.selectedWeapon).gameObject.GetComponent<WeaponID>());
            pastSelectedWeapon = 24023;
        }
    }
}
