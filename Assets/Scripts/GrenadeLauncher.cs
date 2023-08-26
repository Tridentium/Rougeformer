using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrenadeLauncher : MonoBehaviour
{
    public GameObject grenade;
    public PlayerControllerAnimator characterController;
    public float cooldown;
    public float timeToExplode;
    public float explosionDuration;
    public int healing;
    public float damageCooldown;
    public float weaponStrength;

    public WeaponID weaponID;

    float lastTime;
    bool playerFlipped = true;
    Vector2 attackForce;

    private void Start()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerAnimator>();
        weaponID.weaponName = "Help Hurler";
        weaponID.weaponDesc = "A medival weapon created by a renowned engineer using a magic stone found in the king's basement. " +
            "Attacking will create a enegetic sphere thrown from the launcher that will drastically heal enemies in a large radius. " +
             @"
Healing: " + Decimal.Round(((decimal)healing), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Time Until Exlposion: " + Decimal.Round((decimal)timeToExplode, 2) + @"s
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        weaponID.weaponName = "Help Hurler";
        weaponID.weaponDesc = "A medival weapon created by a renowned engineer using a magic stone found in the king's basement. " +
            "Attacking will create a enegetic sphere thrown from the launcher that will drastically heal enemies in a large radius. " +
             @"
Healing: " + Decimal.Round(((decimal)healing), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Time Until Exlposion: " + Decimal.Round((decimal)timeToExplode, 2) + @"s
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        if (Time.time > lastTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
               if (characterController._isFlipped)
                {
                    playerFlipped = false;
                }
                else
                {
                    playerFlipped = true;
                }
                GameObject grenadeItem = Instantiate(grenade, gameObject.transform.position, Quaternion.identity);
                if (playerFlipped)
                {
                    attackForce = new Vector2(1000, 500);
                }
                else
                {
                    attackForce = new Vector2(-1000, 500);
                }

                grenadeItem.gameObject.GetComponent<Rigidbody2D>().AddForce(attackForce);
                grenadeItem.gameObject.GetComponent<GrenadeScript>().timeToExplode = timeToExplode;
                grenadeItem.gameObject.GetComponent<GrenadeScript>().explosionDuration = explosionDuration;
                grenadeItem.gameObject.GetComponent<GrenadeScript>().healing = healing;
                grenadeItem.gameObject.GetComponent<GrenadeScript>().cooldown = damageCooldown;
                grenadeItem.gameObject.GetComponent<GrenadeScript>().weaponID = weaponID;
                lastTime = Time.time + cooldown;
            }
        }

    }
}
