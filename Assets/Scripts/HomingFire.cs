using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HomingFire : MonoBehaviour
{
    public GameObject healingPellet;
    public float cooldown;
    public float range = 10f;
    public float speed = 1f;
    public int healing = 10;
    public float weaponStrength;
    float lastTime;

    public WeaponID weaponID;

    private void Start()
    {
        weaponID.weaponName = "Pellet Parrot";
        weaponID.weaponDesc = "A natural gift found on a stone plinth located in a basin somewhere in the Amazon. " +
            "Attacking will create small healing pellets that will seek out the nearest aid-desirer and heal them on contact. " +
             @"
Healing: " + Decimal.Round(((decimal)healing), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Range: " + Decimal.Round((decimal)range, 2) + @"
Speed: " + Decimal.Round((decimal)speed, 2) + @"
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        weaponID.weaponName = "Pellet Parrot";
        weaponID.weaponDesc = "A natural gift found on a stone plinth located in a basin somewhere in the Amazon. " +
            "Attacking will create small healing pellets that will seek out the nearest aid-desirer and heal them on contact. " +
             @"
Healing: " + Decimal.Round(((decimal)healing), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Range: " + Decimal.Round((decimal)range, 2) + @"
Speed: " + Decimal.Round((decimal)speed, 2) + @"
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        if (Time.time > lastTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject HealingPellet = Instantiate(healingPellet, gameObject.transform.position, Quaternion.identity);
                HealingPellet.GetComponent<HomingScript>().range = range;
                HealingPellet.GetComponent<HomingScript>().speed = speed;
                HealingPellet.GetComponent<HomingScript>().healing = healing;
                HealingPellet.GetComponent<HomingScript>().weaponID = weaponID;
                lastTime = Time.time + cooldown;
            }
        }

    }
}
