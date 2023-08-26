    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGenerator : MonoBehaviour
{
    public GameObject chargeShot;
    public GameObject healingAura;
    public GameObject healingGrenade;
    public GameObject healingHomingBow;
    public GameObject spinningBlade;
    public GameObject swordWallStaff;
    public GameObject emptyArmour;
    public List<GameObject> weaponList;
    public List<float> weaponStrengthList;
    public GameObject[] finalList;
    public Transform shopPanel;
    // Start is called before the first frame update
    void Start()
    {
        finalList = new GameObject[4]; 
        for (int i = 0; i < 4; i++)
        {
            int randomNumber = Mathf.FloorToInt(Random.Range(0, 8.9999999999999f));
            int tierCalculationNumber = Random.Range(0, 101);
            int weaponTier = 1;
            if (tierCalculationNumber < 40)
            {
                weaponTier = 1;
            }
            else if (tierCalculationNumber < 70)
            {
                weaponTier = 2;
            }
            else if (tierCalculationNumber < 85)
            {
                weaponTier = 3;
            }
            else if (tierCalculationNumber < 95)
            {
                weaponTier = 4;
            }
            else
            {
                weaponTier = 5;
            }
            if (randomNumber == 0)
            {
                GameObject item = Instantiate(chargeShot, this.transform);
                float damageMult = Random.Range(4f + (1 * (weaponTier - 1)), 6f + (2.5f * (weaponTier - 1)));
                float cooldown = Random.Range(4f - (0.5f * (weaponTier - 1)), 6f - (0.25f * (weaponTier - 1)));
                float survival = Random.Range(0.1f + (0.1f * (weaponTier - 1)), 0.6f + (0.2f * (weaponTier - 1)));
                item.GetComponent<ChargeShot>().damageMultiplier = damageMult;
                item.GetComponent<ChargeShot>().cooldown = cooldown;
                item.GetComponent<ChargeShot>().survivalTime = survival;
                item.GetComponent<WeaponID>().weaponStrength = ((damageMult / 6f) + (1 - ((cooldown - 4)/2)) + (survival / 0.6f)) / 3;
                item.GetComponent<WeaponID>().tier = weaponTier;
                weaponList.Add(item);
            }
            if (randomNumber == 1)
            {
                GameObject item = Instantiate(healingAura, this.transform);
                float attackTime = Random.Range(0.5f + (0.125f * (weaponTier - 1)), 1.55f + (0.25f * (weaponTier - 1)));
                float cooldown = Random.Range(0.5f - (0.05f * (weaponTier - 1)), 1.5f - (0.125f * (weaponTier - 1)));
                int healing = Mathf.FloorToInt(Random.Range(20f + (5 * (weaponTier - 1)), 40f + (15 * (weaponTier - 1))));
                item.GetComponent<HealingAuraAbility>().attackTime = attackTime;
                item.GetComponent<HealingAuraAbility>().cooldown = cooldown;
                item.GetComponent<HealingAuraAbility>().healing = healing;
                item.GetComponent<WeaponID>().weaponStrength = ((attackTime / 1.55f) + (1 - (cooldown - 0.5f)) + (healing / 40f)) / 3;
                item.GetComponent<WeaponID>().tier = weaponTier;
                weaponList.Add(item);
            }
            if (randomNumber == 2)
            {
                GameObject item = Instantiate(healingGrenade, this.transform);
                float timeToExplode = Random.Range(3f - (0.5f * (weaponTier - 1)), 5f - (0.25f * (weaponTier - 1)));
                float cooldown = Random.Range(4f - (0.5f * (weaponTier - 1)), 6f - (0.25f * (weaponTier - 1)));
                int healing = Mathf.FloorToInt(Random.Range(40f + (10 * (weaponTier - 1)), 60f + (20 * (weaponTier - 1))));
                item.GetComponent<GrenadeLauncher>().timeToExplode = timeToExplode;
                item.GetComponent<GrenadeLauncher>().cooldown = cooldown;
                item.GetComponent<GrenadeLauncher>().healing = healing;
                item.GetComponent<WeaponID>().weaponStrength = ((1 - ((cooldown - 4) / 2f)) + (healing / 60f)) / 2;
                item.GetComponent<WeaponID>().tier = weaponTier;
                weaponList.Add(item);
            }
            if (randomNumber == 3)
            {
                GameObject item = Instantiate(healingHomingBow, this.transform);
                float range = Random.Range(6f + (1f * (weaponTier - 1)), 15f + (2 * (weaponTier - 1)));
                float cooldown = Random.Range(0.25f - (0.035f * (weaponTier - 1)), 0.55f);
                float speed = Random.Range(0.7f + (0.1f * (weaponTier - 1)), 1.5f + (0.2f * (weaponTier - 1)));
                int healing = Mathf.FloorToInt(Random.Range(3f + (1f * (weaponTier - 1)), 10f + (2f * (weaponTier - 1))));
                item.GetComponent<HomingFire>().range = range;
                item.GetComponent<HomingFire>().cooldown = cooldown;
                item.GetComponent<HomingFire>().healing = healing;
                item.GetComponent<HomingFire>().speed = speed;
                item.GetComponent<WeaponID>().weaponStrength = ((range / 15f) + (speed / 1.5f) + (1 - ((cooldown - 0.25f) * 3.33333333f)) + (healing / 10f)) / 4;
                item.GetComponent<WeaponID>().tier = weaponTier;
                weaponList.Add(item);
            }
            if (randomNumber == 4)
            {
                GameObject item = Instantiate(spinningBlade, this.transform);
                float attackTime = Random.Range(0.5f + (0.125f * (weaponTier - 1)), 1.55f + (0.25f * (weaponTier - 1)));
                float cooldown = Random.Range(0.5f - (0.05f * (weaponTier - 1)), 1.5f - (0.125f * (weaponTier - 1)));
                int damage = Mathf.FloorToInt(Random.Range(5 + (2.5f * (weaponTier - 1)), 15f + (7.5f * (weaponTier - 1))));
                item.GetComponent<SpinningBladeAttack>().attackTime = attackTime;
                item.GetComponent<SpinningBladeAttack>().cooldown = cooldown;
                item.GetComponent<SpinningBladeAttack>().damage = damage;
                item.GetComponent<WeaponID>().weaponStrength = ((attackTime / 1.55f) + (1 - (cooldown - 0.5f)) + (damage / 15f)) / 3;
                item.GetComponent<WeaponID>().tier = weaponTier;
                weaponList.Add(item);
            }
            if (randomNumber == 5)
            {
                GameObject item = Instantiate(swordWallStaff, this.transform);
                float range = Random.Range(5f + (1f * (weaponTier - 1)), 20f + (3f * (weaponTier - 1)));
                float cooldown = Random.Range(2f - (0.25f * (weaponTier - 1)), 4f - (0.125f * (weaponTier - 1)));
                float speed = Random.Range(0.7f + (0.25f * (weaponTier - 1)), 1.5f + (0.5f * (weaponTier - 1)));
                int damage = Mathf.FloorToInt(Random.Range(5f + (5f * (weaponTier - 1)), 15f + (10f * (weaponTier - 1))));
                item.GetComponent<CastSwordWall>().range = range;
                item.GetComponent<CastSwordWall>().cooldown = cooldown;
                item.GetComponent<CastSwordWall>().damage = damage;
                item.GetComponent<CastSwordWall>().speed = speed;
                item.GetComponent<WeaponID>().weaponStrength = ((range / 20f) + (speed / 1.5f) + (1 - ((cooldown - 2) / 2f)) + (damage / 15f)) / 4;
                item.GetComponent<WeaponID>().tier = weaponTier;
                weaponList.Add(item);
            }
            if (randomNumber > 5)
            {
                GameObject item = Instantiate(emptyArmour, this.transform);
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
                    if(armourType == 0 && !hasDamageBuff)
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
                weaponList.Add(item);
            }
        }
        foreach (GameObject item in weaponList)
        {
            weaponStrengthList.Add(item.GetComponent<WeaponID>().weaponStrength);
        }
        weaponStrengthList.Sort();
        foreach (GameObject item in weaponList)
        {
            for (int i = 0; i < weaponStrengthList.Count; i++)
            {
                if (item.GetComponent<WeaponID>().weaponStrength == weaponStrengthList[i])
                {
                    finalList[i] = item;
                }
            }
        }
    } 
}
