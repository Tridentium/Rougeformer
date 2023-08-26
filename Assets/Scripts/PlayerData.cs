using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int damage;
    public int currency;
    public int[] partsStorage;
    public float[] position;
    public float[][] inventory;
    public PlayerData (PlayerManagement player)
    {
        inventory = new float[20][];
        damage = player.playerHealth;
        currency = player.currency;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        partsStorage = player.partsStorage;
        //inventory
        GameObject InventoryStorage = player.gameObject.transform.Find("InventoryStorage").gameObject;
        for (int i = 0; i < InventoryStorage.transform.childCount; i++)
        {
            int weaponIndex = 0;
            inventory[i] = new float[20];
            if (InventoryStorage.transform.GetChild(i).gameObject.name.Contains("Charge Shot"))
            {
                weaponIndex = 1;
                inventory[i][2] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<ChargeShot>().damageMultiplier;
                inventory[i][3] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<ChargeShot>().cooldown;
                inventory[i][4] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<ChargeShot>().survivalTime;
                inventory[i][5] = ((inventory[i][2] / 6f) + (1 - ((inventory[i][3] - 4) / 2)) + (inventory[i][4] / 0.6f)) / 3;
                inventory[i][6] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<WeaponID>().tier;
            }
            if (InventoryStorage.transform.GetChild(i).gameObject.name.Contains("Healing Aura Staff"))
            {
                weaponIndex = 2;
                inventory[i][2] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<HealingAuraAbility>().attackTime;
                inventory[i][3] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<HealingAuraAbility>().cooldown;
                inventory[i][4] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<HealingAuraAbility>().healing;
                inventory[i][5] = ((inventory[i][2] / 1.55f) + (1 - (inventory[i][3] - 0.5f)) + (inventory[i][4] / 40f)) / 3;
                inventory[i][6] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<WeaponID>().tier;
            }
            if (InventoryStorage.transform.GetChild(i).gameObject.name.Contains("Healing Grenade Launcher"))
            {
                weaponIndex = 3;
                inventory[i][2] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<GrenadeLauncher>().timeToExplode;
                inventory[i][3] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<GrenadeLauncher>().cooldown;
                inventory[i][4] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<GrenadeLauncher>().healing;
                inventory[i][5] = ((1 - ((inventory[i][3] - 4) / 2f)) + (inventory[i][4] / 60f)) / 2;
                inventory[i][6] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<WeaponID>().tier;
            }
            if (InventoryStorage.transform.GetChild(i).gameObject.name.Contains("Healing Homing Bow"))
            {
                weaponIndex = 4;
                inventory[i][2] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<HomingFire>().range;
                inventory[i][3] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<HomingFire>().cooldown;
                inventory[i][4] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<HomingFire>().healing;
                inventory[i][5] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<HomingFire>().speed;
                inventory[i][6] = ((inventory[i][2] / 15f) + (inventory[i][5] / 1.5f) + (1 - ((inventory[i][3] - 0.25f) * 3.33333333f)) + (inventory[i][4] / 10f)) / 4;
                inventory[i][7] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<WeaponID>().tier;
            }
            if (InventoryStorage.transform.GetChild(i).gameObject.name.Contains("Spinning Blade"))
            {
                weaponIndex = 5;
                inventory[i][2] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<SpinningBladeAttack>().attackTime;
                inventory[i][3] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<SpinningBladeAttack>().cooldown;
                inventory[i][4] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<SpinningBladeAttack>().damage;
                inventory[i][5] = ((inventory[i][2] / 1.55f) + (1 - (inventory[i][3] - 0.5f)) + (inventory[i][4] / 15f)) / 3;
                inventory[i][6] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<WeaponID>().tier;
            }
            if (InventoryStorage.transform.GetChild(i).gameObject.name.Contains("Sword Wall Staff"))
            {
                weaponIndex = 6;
                inventory[i][2] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<CastSwordWall>().range;
                inventory[i][3] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<CastSwordWall>().cooldown;
                inventory[i][4] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<CastSwordWall>().damage;
                inventory[i][5] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<CastSwordWall>().speed;
                inventory[i][6] = ((inventory[i][2] / 150f) + (inventory[i][5] / 1.5f) + (1 - ((inventory[i][3] - 2) / 2f)) + (inventory[i][4] / 15f)) / 4;
                inventory[i][7] = InventoryStorage.transform.GetChild(i).gameObject.GetComponent<WeaponID>().tier;

            }
            if (InventoryStorage.transform.GetChild(i).gameObject.name.Contains("Empty Armour"))
            {
                weaponIndex = 7;
                GameObject armourItem = InventoryStorage.transform.GetChild(i).gameObject;
                if(armourItem.GetComponent<DamageBuffArmour>() != null)
                {
                    inventory[i][2] = 1;
                    inventory[i][3] = armourItem.GetComponent<DamageBuffArmour>().buffTime;
                    inventory[i][4] = armourItem.GetComponent<DamageBuffArmour>().buff;
                }
                if (armourItem.GetComponent<HealingBuffArmour>() != null)
                {
                    inventory[i][5] = 1;
                    inventory[i][6] = armourItem.GetComponent<HealingBuffArmour>().buffTime;
                    inventory[i][7] = armourItem.GetComponent<HealingBuffArmour>().buff;
                }
                if (armourItem.GetComponent<KbResistanceArmour>() != null)
                {
                    inventory[i][8] = 1;
                    inventory[i][9] = armourItem.GetComponent<KbResistanceArmour>().buff;
                }
                if (armourItem.GetComponent<KbAttacked>() != null)
                {
                    inventory[i][10] = 1;
                    inventory[i][11] = armourItem.GetComponent<KbAttacked>().respondAmount;
                }
                if (armourItem.GetComponent<ThornsArmourTrigger>() != null)
                {
                    inventory[i][12] = 1;
                    inventory[i][13] = armourItem.GetComponent<ThornsArmourTrigger>().respondPercent;
                }

            }

            inventory[i][0] = i;
            inventory[i][1] = weaponIndex;
        }
    }
}
