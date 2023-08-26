using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CastSwordWall : MonoBehaviour
{
    public GameObject swordWall;
    public float cooldown;
    public float range = 100f;
    public float speed = 1f;
    public int damage = 10;
    public float damageCooldown = 0.5f;
    public float weaponStrength;
    float lastTime;
    
    public WeaponID weaponID;
    private void Start()
    {
        weaponID.weaponName = "Weapon Wall";
        weaponID.weaponDesc = "Dark staff forged by a necromancer. Thought to be destroyed after her death, it was later found in a skip in modern day Texas. " +
            "Attacking will summon a wall of swords that will travel towards enemies, dealing damage on collision. " +
             @"
Damage: " + Decimal.Round(((decimal)damage), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Range: " + Decimal.Round((decimal)range, 2) + @"
Speed: " + Decimal.Round((decimal)speed, 2) + @"
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);

        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        weaponID.weaponName = "Weapon Wall";
        weaponID.weaponDesc = "Dark staff forged by a necromancer. Thought to be destroyed after her death, it was later found in a skip in modern day Texas. " +
            "Attacking will summon a wall of swords that will travel towards enemies, dealing damage on collision. " +
             @"
Damage: " + Decimal.Round(((decimal)damage), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Range: " + Decimal.Round((decimal)range, 2) + @"
Speed: " + Decimal.Round((decimal)speed, 2) + @"
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        if (Time.time > lastTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject SwordWall = Instantiate(swordWall, gameObject.transform.position, Quaternion.identity);
                SwordWall.GetComponent<SwordWallTravel>().range = range;
                SwordWall.GetComponent<SwordWallTravel>().speed = speed;
                SwordWall.GetComponent<SwordWallTravel>().damage = damage;
                SwordWall.GetComponent<SwordWallTravel>().cooldown = damageCooldown;
                SwordWall.GetComponent <SwordWallTravel>().weaponID = weaponID;
                lastTime = Time.time + cooldown;
            }
        }

    }
}
