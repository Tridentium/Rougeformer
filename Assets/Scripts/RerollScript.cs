using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollScript : MonoBehaviour
{
    public WeaponID weaponID;
   public void RerollItem (GameObject item, WeaponID weaponID)
    {
        if (item.GetComponent<ChargeShot>() != null)
        {
            float damageMult = Random.Range(4f + (1 * (weaponID.tier - 1)), 6f + (2.5f * (weaponID.tier - 1)));
            float cooldown = Random.Range(4f - (0.5f * (weaponID.tier - 1)), 6f - (0.25f * (weaponID.tier - 1)));
            float survival = Random.Range(0.1f + (0.1f * (weaponID.tier - 1)), 0.6f + (0.2f * (weaponID.tier - 1)));
            item.GetComponent<ChargeShot>().damageMultiplier = damageMult;
            item.GetComponent<ChargeShot>().cooldown = cooldown;
            item.GetComponent<ChargeShot>().survivalTime = survival;
            item.GetComponent<WeaponID>().weaponStrength = ((damageMult / 6f) + (1 - ((cooldown - 4) / 2)) + (survival / 0.6f)) / 3;
        }
        if (item.GetComponent<HealingAuraAbility>() != null)
        {
            float attackTime = Random.Range(0.5f + (0.125f * (weaponID.tier - 1)), 1.55f + (0.25f * (weaponID.tier - 1)));
            float cooldown = Random.Range(0.5f - (0.05f * (weaponID.tier - 1)), 1.5f - (0.125f * (weaponID.tier - 1)));
            int healing = Mathf.FloorToInt(Random.Range(20f + (5 * (weaponID.tier - 1)), 40f + (15 * (weaponID.tier - 1))));
            item.GetComponent<HealingAuraAbility>().attackTime = attackTime;
            item.GetComponent<HealingAuraAbility>().cooldown = cooldown;
            item.GetComponent<HealingAuraAbility>().healing = healing;
            item.GetComponent<WeaponID>().weaponStrength = ((attackTime / 1.55f) + (1 - (cooldown - 0.5f)) + (healing / 40f)) / 3;
        }
        if (item.GetComponent<GrenadeLauncher>() != null)
        {
            float timeToExplode = Random.Range(3f - (0.5f * (weaponID.tier - 1)), 5f - (0.25f * (weaponID.tier - 1)));
            float cooldown = Random.Range(4f - (0.5f * (weaponID.tier - 1)), 6f - (0.25f * (weaponID.tier - 1)));
            int healing = Mathf.FloorToInt(Random.Range(40f + (10 * (weaponID.tier - 1)), 60f + (20 * (weaponID.tier - 1))));
            item.GetComponent<GrenadeLauncher>().timeToExplode = timeToExplode;
            item.GetComponent<GrenadeLauncher>().cooldown = cooldown;
            item.GetComponent<GrenadeLauncher>().healing = healing;
            item.GetComponent<WeaponID>().weaponStrength = ((1 - ((cooldown - 4) / 2f)) + (healing / 60f)) / 2;
        }
        if (item.GetComponent<HomingFire>() != null)
        {
            float range = Random.Range(6f + (1f * (weaponID.tier - 1)), 15f + (2 * (weaponID.tier - 1)));
            float cooldown = Random.Range(0.25f - (0.035f * (weaponID.tier - 1)), 0.55f);
            float speed = Random.Range(0.7f + (0.1f * (weaponID.tier - 1)), 1.5f + (0.2f * (weaponID.tier - 1)));
            int healing = Mathf.FloorToInt(Random.Range(3f + (1f * (weaponID.tier - 1)), 10f + (2f * (weaponID.tier - 1))));
            item.GetComponent<HomingFire>().range = range;
            item.GetComponent<HomingFire>().cooldown = cooldown;
            item.GetComponent<HomingFire>().healing = healing;
            item.GetComponent<HomingFire>().speed = speed;
            item.GetComponent<WeaponID>().weaponStrength = ((range / 15f) + (speed / 1.5f) + (1 - ((cooldown - 0.25f) * 3.33333333f)) + (healing / 10f)) / 4;
        }
        if (item.GetComponent<SpinningBladeAttack>() != null)
        {
            float attackTime = Random.Range(0.5f + (0.125f * (weaponID.tier - 1)), 1.55f + (0.25f * (weaponID.tier - 1)));
            float cooldown = Random.Range(0.5f - (0.05f * (weaponID.tier - 1)), 1.5f - (0.125f * (weaponID.tier - 1)));
            int damage = Mathf.FloorToInt(Random.Range(5 + (2.5f * (weaponID.tier - 1)), 15f + (7.5f * (weaponID.tier - 1))));
            item.GetComponent<SpinningBladeAttack>().attackTime = attackTime;
            item.GetComponent<SpinningBladeAttack>().cooldown = cooldown;
            item.GetComponent<SpinningBladeAttack>().damage = damage;
            item.GetComponent<WeaponID>().weaponStrength = ((attackTime / 1.55f) + (1 - (cooldown - 0.5f)) + (damage / 15f)) / 3;
        }
        if (item.GetComponent<CastSwordWall>() != null)
        {
            float range = Random.Range(5f + (1f * (weaponID.tier - 1)), 20f + (3f * (weaponID.tier - 1)));
            float cooldown = Random.Range(2f - (0.25f * (weaponID.tier - 1)), 4f - (0.125f * (weaponID.tier - 1)));
            float speed = Random.Range(0.7f + (0.25f * (weaponID.tier - 1)), 1.5f + (0.5f * (weaponID.tier - 1)));
            int damage = Mathf.FloorToInt(Random.Range(5f + (5f * (weaponID.tier - 1)), 15f + (10f * (weaponID.tier - 1))));
            item.GetComponent<CastSwordWall>().range = range;
            item.GetComponent<CastSwordWall>().cooldown = cooldown;
            item.GetComponent<CastSwordWall>().damage = damage;
            item.GetComponent<CastSwordWall>().speed = speed;
            item.GetComponent<WeaponID>().weaponStrength = ((range / 20f) + (speed / 1.5f) + (1 - ((cooldown - 2) / 2f)) + (damage / 15f)) / 4;
        }
        if (item.GetComponent<TooltipArmourNaming>() != null)
        {
            int howManyStats = Random.Range(1, 6);
            int armourAbilitiesCount = 0;
            bool hasDamageBuff = false;
            bool hasHealingBuff = false;
            bool hasKbResistance = false;
            bool hasKbRespond = false;
            bool hasThornsArmour = false;
            int[] statsGenerator = new int[5];
            statsGenerator[0] = 0;
            statsGenerator[1] = 1;
            statsGenerator[2] = 2;
            statsGenerator[3] = 3;
            statsGenerator[4] = 4;
            int tempInt = 0;
            for (int h = 0; h < statsGenerator.Length; h++)
            {
                int rnd = Random.Range(0, statsGenerator.Length);
                tempInt = statsGenerator[rnd];
                statsGenerator[rnd] = statsGenerator[h];
                statsGenerator[h] = tempInt;
            }
            for (int j = 0; j < howManyStats; j++)
            {
                int armourType = statsGenerator[j];
                if (armourType == 0 && !hasDamageBuff)
                {
                    float buff = Random.Range(0.3f, 1f);
                    float time = Random.Range(3f, 7f);
                    item.AddComponent<DamageBuffArmour>();
                    item.GetComponent<DamageBuffArmour>().buffTime = time;
                    item.GetComponent<DamageBuffArmour>().buff = buff;
                    hasDamageBuff = true;
                    item.GetComponent<WeaponID>().weaponStrength += (((buff / 1) + (time / 7)) / 2) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (armourType == 1 && !hasHealingBuff)
                {
                    float buff = Random.Range(0.3f, 1f);
                    float time = Random.Range(3f, 7f);
                    item.AddComponent<HealingBuffArmour>();
                    item.GetComponent<HealingBuffArmour>().buffTime = time;
                    item.GetComponent<HealingBuffArmour>().buff = buff;
                    hasHealingBuff = true;
                    item.GetComponent<WeaponID>().weaponStrength += (((buff / 1) + (time / 7)) / 2) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (armourType == 2 && !hasKbResistance)
                {
                    float buff = Random.Range(0.2f, 0.8f);
                    item.AddComponent<KbResistanceArmour>();
                    item.GetComponent<KbResistanceArmour>().buff = buff;
                    hasKbResistance = true;
                    item.GetComponent<WeaponID>().weaponStrength += (buff / 1.5f) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (armourType == 3 && !hasKbRespond)
                {
                    float buff = Random.Range(700f, 1500f);
                    item.AddComponent<KbAttacked>();
                    item.GetComponent<KbAttacked>().respondAmount += buff;
                    hasKbRespond = true;
                    item.GetComponent<WeaponID>().weaponStrength = (buff / 1500f) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (armourType == 4 && !hasThornsArmour)
                {
                    float buff = Random.Range(0.3f, 1f);
                    item.AddComponent<ThornsArmourTrigger>();
                    item.GetComponent<ThornsArmourTrigger>().respondPercent = buff;
                    hasThornsArmour = true;
                    item.GetComponent<WeaponID>().weaponStrength += (buff / 1f) * 0.02f;
                    armourAbilitiesCount++;
                }
            }
            item.GetComponent<WeaponID>().weaponStrength += (armourAbilitiesCount * 0.18f);
        }
    }
}
