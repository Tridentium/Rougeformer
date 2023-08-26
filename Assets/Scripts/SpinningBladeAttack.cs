using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpinningBladeAttack : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public float attackTime = 1f;
    public float cooldown;
    public float damageCooldown = 0.5f;
    public int damage = 10;
    public ArmourStats armourStats;
    public float weaponStrength;

    public WeaponID weaponID;

    float lastTime;
    float damageLastTime;
    private void Start()
    {
        circleCollider.enabled = false;
        armourStats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArmourStats>();
        weaponID.weaponName = "Blade Blizzard";
        weaponID.weaponDesc = "A sharp scythe wielded by an eaons-old bounty hunter. " +
            "Attacking will create a deadly circle around the player that slices and damages enemies. " +
             @"
Damage: " + Decimal.Round(((decimal)damage), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Attack Time: " + Decimal.Round((decimal)attackTime, 2) + @"s
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        weaponID.weaponName = "Blade Blizzard";
        weaponID.weaponDesc = "A sharp scythe wielded by an eaons-old bounty hunter. " +
            "Attacking will create a deadly circle around the player that slices and damages enemies. " +
             @"
Damage: " + Decimal.Round(((decimal)damage), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Attack Time: " + Decimal.Round((decimal)attackTime, 2) + @"s
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        if (Time.time > lastTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(spinnyActivate());
                lastTime = Time.time + cooldown + attackTime;
            }
        }

        if (circleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            if (Time.time > damageLastTime)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (circleCollider.IsTouching(enemy.GetComponent<BoxCollider2D>()))
                    {
                        enemy.GetComponent<EnemyStats>().health -= Mathf.FloorToInt(damage * armourStats.damageBuff * weaponID.tierBuff);
                        Vector2 attackForce = new Vector2(1000, 2000);
                        enemy.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(attackForce);
                        damageLastTime = Time.time + damageCooldown;
                    }
                }
            }
        }
    }

    IEnumerator spinnyActivate()
    {
        circleCollider.enabled = true;
        yield return new WaitForSeconds(attackTime);
        circleCollider.enabled = false;
    }
}
