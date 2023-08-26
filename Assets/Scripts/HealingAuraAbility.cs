using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealingAuraAbility : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public SpriteRenderer healingRing;
    public float attackTime = 1f;
    public float cooldown;
    public float damageCooldown = 0.5f;
    public int healing = 10;
    public float weaponStrength;
    public ArmourStats armourStats;

    public WeaponID weaponID;

    float lastTime;
    float damageLastTime;
    private void Start()
    {
        circleCollider.enabled = false;
        healingRing.color = new Color(healingRing.color.r, healingRing.color.g, healingRing.color.b, 0);
        armourStats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArmourStats>();
        weaponID.weaponName = "Sustanence Staff";
        weaponID.weaponDesc = "A magical staff created long ago by a benevolent wizard. " +
            "Attacking will create a magical sphere around the player that heals enemies. " +
             @"
Healing: " + Decimal.Round(((decimal)healing), 2) + @"
Cooldown: " + Decimal.Round((decimal)cooldown, 2) + @"s
Attack Time: " + Decimal.Round((decimal)attackTime, 2) + @"s
Tier: " + weaponID.tier + @"
Weapon Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        weaponID.weaponName = "Sustanence Staff";
        weaponID.weaponDesc = "A magical staff created long ago by a benevolent wizard. " +
            "Attacking will create a magical sphere around the player that heals enemies. " +
             @"
Healing: " + Decimal.Round(((decimal)healing), 2) + @"
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
                        enemy.GetComponent<EnemyStats>().health += Mathf.FloorToInt(healing * armourStats.healingBuff * weaponID.tierBuff);
                        damageLastTime = Time.time + damageCooldown;
                    }
                }
            }
        }
    }

    IEnumerator spinnyActivate()
    {
        circleCollider.enabled = true;
        healingRing.color = new Color(healingRing.color.r, healingRing.color.g, healingRing.color.b, 255);
        yield return new WaitForSeconds(attackTime);
        circleCollider.enabled = false;
        healingRing.color = new Color(healingRing.color.r, healingRing.color.g, healingRing.color.b, 0);
    }
}

