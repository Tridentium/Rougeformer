using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TierUpSlotTooltip : MonoBehaviour
{
    public WeaponManager manager;
    public Image weaponImage;
    public TierUpTooltipTrigger trigger;
    public Color colour;


    public string header;
    [Multiline()]
    public string content;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (manager.transform.GetChild(manager.selectedWeapon).gameObject.tag != "TempSlot")
        {
            weaponImage.color = new Color(1, 1, 1, 1);
            weaponImage.sprite = manager.transform.GetChild(manager.selectedWeapon).GetComponent<SpriteRenderer>().sprite;
            trigger.header = manager.transform.GetChild(manager.selectedWeapon).gameObject.GetComponent<WeaponID>().weaponName;
            trigger.content = manager.transform.GetChild(manager.selectedWeapon).gameObject.GetComponent<WeaponID>().weaponDesc;
            header = manager.transform.GetChild(manager.selectedWeapon).gameObject.GetComponent<WeaponID>().weaponName;
            content = manager.transform.GetChild(manager.selectedWeapon).gameObject.GetComponent<WeaponID>().weaponDesc;
            if (manager.transform.GetChild(manager.selectedWeapon).GetComponent<WeaponID>().tier == 0)
            {
                this.GetComponent<Image>().color = new Color(1, 1, 1, 0.7843137f);
                colour = new Color(1, 1, 1, 0.7843137f);
            }
            if (manager.transform.GetChild(manager.selectedWeapon).GetComponent<WeaponID>().tier == 1)
            {
                this.GetComponent<Image>().color = new Color(1, 1, 1, 0.7843137f);
                colour = new Color(1, 1, 1, 0.7843137f);
            }
            if (manager.transform.GetChild(manager.selectedWeapon).GetComponent<WeaponID>().tier == 2)
            {
                this.GetComponent<Image>().color = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
                colour = new Color(0.514151f, 1, 0.7927338f, 0.7843137f);
            }
            if (manager.transform.GetChild(manager.selectedWeapon).GetComponent<WeaponID>().tier == 3)
            {
                this.GetComponent<Image>().color = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
                colour = new Color(0.9187506f, 0.5740477f, 0.9433962f, 0.7843137f);
            }
            if (manager.transform.GetChild(manager.selectedWeapon).GetComponent<WeaponID>().tier == 4)
            {
                this.GetComponent<Image>().color = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
                colour = new Color(0.8301887f, 0.4503382f, 0.4503382f, 0.7843137f);
            }
            if (manager.transform.GetChild(manager.selectedWeapon).GetComponent<WeaponID>().tier == 5)
            {
                this.GetComponent<Image>().color = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
                colour = new Color(0.9758545f, 1f, 0.6745283f, 0.7843137f);
            }
        }
        else
        {
            weaponImage.sprite = null;
            weaponImage.color = new Color(0, 0, 0, 0);
            this.GetComponent<Image>().color = new Color(1, 1, 1, 0.7843137f);
            colour = new Color(1, 1, 1, 0.7843137f);
            trigger.header = "Empty Slot";
            trigger.content = "Contrary to popular opinon, the void of an empty slot actually allows for infinite possibilities";
            header = "An Empty Slot";
            content = "Contrary to popular opinon, the void of an empty slot actually allows for infinite possibilities";
        }
    }
}
