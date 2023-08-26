using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int selectedWeapon = 0;
    void Start()
    {
        StartCoroutine(start());
    }
    IEnumerator justFuckingLoadTheShit()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.005f);
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.005f);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator start()
    {
        StartCoroutine(justFuckingLoadTheShit());
        yield return new WaitForSeconds(0.5f);
        selectWeapon();
    }
    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }
    }

    void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                if(weapon.gameObject.tag != "Armour")
                {
                    weapon.gameObject.SetActive(false);
                }
            }
            i++;
        }
    }
}
