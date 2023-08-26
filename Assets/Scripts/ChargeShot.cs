using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChargeShot : MonoBehaviour
{
    public GameObject lazBem;
    public float cooldown;
    public float maxChargeTime = 2f;
    public float damageCooldown = 0.5f;
    public float damageMultiplier = 5;
    public float survivalTime = 0.3f;
    public float weaponStrength;

    public WeaponID weaponID;

    float chargeTime;
    float lastTime;
    Vector3 newPosition;

    public bool playerFlipped = true;
    PlayerControllerAnimator characterController;

    private void Start()
    {
        weaponID.weaponName = "Charge Chonker";
        weaponID.weaponDesc = "A charge rifle developed in a high tech modern society. " +
            "Holding down fire will result in a shot, with a longer held time dealing more damage " +
            "and resulting in a higher death zone." + @"
Damage: " + Decimal.Round(((decimal)damageMultiplier), 2) + @"x
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Survival Time: " + Decimal.Round((decimal)survivalTime, 2) + @"s
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        weaponID.weaponName = "Charge Chonker";
        weaponID.weaponDesc = "A charge rifle developed in a high tech modern society. " +
            "Holding down fire will result in a shot, with a longer held time dealing more damage " +
            "and resulting in a higher death zone." + @"
Damage: " + Decimal.Round(((decimal)damageMultiplier), 2) + @"x
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Survival Time: " + Decimal.Round((decimal)survivalTime, 2) + @"s
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerAnimator>();
        if (!characterController._isFlipped)
        {
            playerFlipped = false;
        }
        else
        {
            playerFlipped = true;
        }
        if (Time.time >= lastTime)
        {
            if(chargeTime > maxChargeTime)
            {
                if (!playerFlipped)
                {
                    newPosition = new Vector3(gameObject.transform.position.x + (chargeTime * 2) + (0.1f / chargeTime) + 0.1f, gameObject.transform.position.y, 0);
                }
                else
                {
                    newPosition = new Vector3(gameObject.transform.position.x - (chargeTime * 2) + (0.1f / chargeTime) + 0.1f, gameObject.transform.position.y, 0);

                }
                GameObject lazerBeam = Instantiate(lazBem, newPosition, Quaternion.identity);
                lazerBeam.transform.localScale *= (chargeTime * 2);
                lazerBeam.GetComponent<LazarBeamDamage>().damage += Mathf.FloorToInt((int)chargeTime * damageMultiplier);
                lazerBeam.GetComponent<LazarBeamDamage>().cooldown = damageCooldown;
                lazerBeam.GetComponent<LazarBeamDamage>().survivalTime = survivalTime;
                lastTime = Time.time + cooldown;
                chargeTime = 0;
                return;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                chargeTime = 0;
            }
            else if (Input.GetButton("Fire1"))
            {
                chargeTime += 1 * Time.deltaTime;
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                if (!playerFlipped)
                {
                    newPosition = new Vector3(gameObject.transform.position.x + (chargeTime * 2) + (0.1f / chargeTime) + 0.1f, gameObject.transform.position.y, 0);
                }
                else
                {
                    newPosition = new Vector3(gameObject.transform.position.x - (chargeTime * 2) + (0.1f / chargeTime) + 0.1f, gameObject.transform.position.y, 0);

                };
                GameObject lazerBeam = Instantiate(lazBem, newPosition, Quaternion.identity);
                lazerBeam.transform.localScale *= (chargeTime * 2) + 1;
                lazerBeam.GetComponent<LazarBeamDamage>().damage += Mathf.FloorToInt((int)chargeTime * damageMultiplier);
                lazerBeam.GetComponent<LazarBeamDamage>().weaponID = weaponID;
                lastTime = Time.time + cooldown;
            }
        }
    }
}
