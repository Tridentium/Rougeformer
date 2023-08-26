using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManagement : MonoBehaviour
{
    public bool loadOnStart = true;
    public Transform inventory;

    public int currency = 0;
    public int levelCurrency = 0;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI levelCurrencyText;

    public Canvas playerDeathScreen;

    public int playerHealth = 0;
    public TextMeshProUGUI healthText;

    public TextMeshProUGUI heightText;

    public GameObject attacker;
    public int damageTaken;

    bool recieved;
    bool inputGiven;

    public TextMeshProUGUI partsText;

    public GameObject chargeShot;
    public GameObject healingAura;
    public GameObject healingGrenade;
    public GameObject healingHoming;
    public GameObject spinningBlade;
    public GameObject swordWall;
    public GameObject emptyArmour;
    public GameObject tempSlot;
    public int[] partsStorage;
    // Start is called before the first frame update
    private void Awake()
    {
        partsStorage = new int[15];
        if (loadOnStart)
        {
            LoadPlayer();
            if (partsStorage == null)
            {
                partsStorage = new int[15];
            }
        }

        for (int i = 0; i < inventory.childCount; i++)
        {
            inventory.GetChild(i).gameObject.SetActive(true);
        }
        this.transform.position = new Vector3(-7.57f, -2.26f, 0);

        if (playerDeathScreen != null)
        {
            playerDeathScreen.enabled = false;
        }
        recieved = false;
        inputGiven = false;
        levelCurrency = 0;
    }
    private void OnApplicationQuit()
    {
        SavePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        if (partsText != null)
        {
            partsText.text = @"T1: " + partsStorage[0] + " leaves," + partsStorage[1] + " sticks, " + partsStorage[2] + " dirt" +
    @"
T2: " + partsStorage[3] + " rocks, " + partsStorage[4] + " wooden screws, " + partsStorage[5] + " metal shards" +
    @"
T3: " + partsStorage[6] + " metal components, " + partsStorage[7] + " copper wire, " + partsStorage[8] + " broken machinery" +
    @"
T4: " + partsStorage[9] + " spare parts, " + partsStorage[10] + " essence of alcheron, " + partsStorage[11] + " part of the earth's motlen core" +
    @"
T5: " + partsStorage[12] + " alcheron crystals, " + partsStorage[13] + " solar spirits, " + partsStorage[14] + " gaia's gists";
        }
        currencyText.text = currency.ToString();
        if (levelCurrencyText != null)
        {
            levelCurrencyText.text = levelCurrency.ToString();
            heightText.text = "Height: " + (Mathf.FloorToInt((this.gameObject.transform.position.y + 5)/2)).ToString();
        }
        healthText.text = playerHealth.ToString();

        if (gameObject.transform.position.y < -50)
        {
            if (playerDeathScreen != null)
            {
                InGameDeath();
            }
            else
            {
                gameObject.transform.position = new Vector3(0, 0, 0);
                SavePlayer();
                SceneManager.LoadScene(0);
            }
        }

    }

    void InGameDeath()
    {
        playerDeathScreen.enabled = true;
    }

    public void grantCurrency()
    {
        if(recieved == false)
        {
            currency += levelCurrency;
            recieved = true;
            inputGiven = true;
            SavePlayer();
            SceneManager.LoadScene(0);
        }
    }
    public void grantParts()
    {
        if (recieved == false)
        {
            for (int i = 0; i < levelCurrency/10; i++)
            {
                int randomNumber = Random.Range(0, 15);
                partsStorage[randomNumber] += Random.Range(1, 3);
            }
            recieved = true;
            inputGiven = true;
            SavePlayer();
            SceneManager.LoadScene(0);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        currency = data.currency;
        //playerHealth = data.damage;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        partsStorage = data.partsStorage;

        GameObject InventoryStorage = this.gameObject.transform.Find("InventoryStorage").gameObject;
        int inventoryChildren = InventoryStorage.transform.childCount;
        for (int i = 0; i < InventoryStorage.transform.childCount; i++)
        {
            GameObject child = InventoryStorage.transform.GetChild(i).gameObject;
            Destroy(child);
        }
        for (int i = 0; i < inventoryChildren; i++)
        {
            if (data.inventory[i][1] == 1)
            {
                GameObject ChargeShotObject = Instantiate(chargeShot, InventoryStorage.transform);
                ChargeShot ChargeShotScript = ChargeShotObject.GetComponent<ChargeShot>();
                WeaponID ChargeShotID = ChargeShotObject.GetComponent<WeaponID>();
                ChargeShotScript.damageMultiplier = data.inventory[i][2];
                ChargeShotScript.cooldown = data.inventory[i][3];
                ChargeShotScript.survivalTime = data.inventory[i][4];
                ChargeShotID.weaponStrength = data.inventory[i][5];
                ChargeShotID.tier = (int)data.inventory[i][6];
            }
            else if (data.inventory[i][1] == 2)
            {
                GameObject HealingAuraObject = Instantiate(healingAura, InventoryStorage.transform);
                HealingAuraAbility ChargeShotScript = HealingAuraObject.GetComponent<HealingAuraAbility>();
                WeaponID ChargeShotID = HealingAuraObject.GetComponent<WeaponID>();
                ChargeShotScript.attackTime = data.inventory[i][2];
                ChargeShotScript.cooldown = data.inventory[i][3];
                ChargeShotScript.healing = (int)data.inventory[i][4];
                ChargeShotID.weaponStrength = data.inventory[i][5];
                ChargeShotID.tier = (int)data.inventory[i][6];
            }
            else if (data.inventory[i][1] == 3)
            {
                GameObject HealingAuraObject = Instantiate(healingGrenade, InventoryStorage.transform);
                GrenadeLauncher ChargeShotScript = HealingAuraObject.GetComponent<GrenadeLauncher>();
                WeaponID ChargeShotID = HealingAuraObject.GetComponent<WeaponID>();
                ChargeShotScript.timeToExplode = data.inventory[i][2];
                ChargeShotScript.cooldown = data.inventory[i][3];
                ChargeShotScript.healing = (int)data.inventory[i][4];
                ChargeShotID.weaponStrength = data.inventory[i][5];
                ChargeShotID.tier = (int)data.inventory[i][6];
            }
            else if (data.inventory[i][1] == 4)
            {
                GameObject HealingAuraObject = Instantiate(healingHoming, InventoryStorage.transform);
                HomingFire ChargeShotScript = HealingAuraObject.GetComponent<HomingFire>();
                WeaponID ChargeShotID = HealingAuraObject.GetComponent<WeaponID>();
                ChargeShotScript.range = data.inventory[i][2];
                ChargeShotScript.cooldown = data.inventory[i][3];
                ChargeShotScript.healing = (int)data.inventory[i][4];
                ChargeShotScript.speed = data.inventory[i][5];
                ChargeShotID.weaponStrength = data.inventory[i][6];
                ChargeShotID.tier = (int)data.inventory[i][7];
            }
            else if (data.inventory[i][1] == 5)
            {
                GameObject HealingAuraObject = Instantiate(spinningBlade, InventoryStorage.transform);
                SpinningBladeAttack ChargeShotScript = HealingAuraObject.GetComponent<SpinningBladeAttack>();
                WeaponID ChargeShotID = HealingAuraObject.GetComponent<WeaponID>();
                ChargeShotScript.attackTime = data.inventory[i][2];
                ChargeShotScript.cooldown = data.inventory[i][3];
                ChargeShotScript.damage = (int)data.inventory[i][4];
                ChargeShotID.weaponStrength = data.inventory[i][5];
                ChargeShotID.tier = (int)data.inventory[i][6];
            }
            else if (data.inventory[i][1] == 6)
            {
                GameObject HealingAuraObject = Instantiate(swordWall, InventoryStorage.transform);
                CastSwordWall ChargeShotScript = HealingAuraObject.GetComponent<CastSwordWall>();
                WeaponID ChargeShotID = HealingAuraObject.GetComponent<WeaponID>();
                ChargeShotScript.range = data.inventory[i][2];
                ChargeShotScript.cooldown = data.inventory[i][3];
                ChargeShotScript.damage = (int)data.inventory[i][4];
                ChargeShotScript.speed = data.inventory[i][5];
                ChargeShotID.weaponStrength = data.inventory[i][6];
                ChargeShotID.tier = (int)data.inventory[i][7];
            }
            else if (data.inventory[i][1] == 7)
            {
                int armourAbilitiesCount = 0;
                GameObject armour = Instantiate(emptyArmour, InventoryStorage.transform);
                if (data.inventory[i][2] == 1)
                {
                    armour.AddComponent<DamageBuffArmour>();
                    armour.GetComponent<DamageBuffArmour>().buffTime = data.inventory[i][3];
                    armour.GetComponent<DamageBuffArmour>().buff = data.inventory[i][4];
                    armour.GetComponent<WeaponID>().weaponStrength += (((data.inventory[i][4] / 1) + (data.inventory[i][3] / 7)) / 2) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (data.inventory[i][5] == 1)
                {
                    armour.AddComponent<HealingBuffArmour>();
                    armour.GetComponent<HealingBuffArmour>().buffTime = data.inventory[i][6];
                    armour.GetComponent<HealingBuffArmour>().buff = data.inventory[i][7];
                    armour.GetComponent<WeaponID>().weaponStrength += (((data.inventory[i][7] / 1) + (data.inventory[i][6] / 7)) / 2) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (data.inventory[i][8] == 1)
                {
                    armour.AddComponent<KbResistanceArmour>();
                    armour.GetComponent<KbResistanceArmour>().buff = data.inventory[i][9];
                    armour.GetComponent<WeaponID>().weaponStrength += (data.inventory[i][9] / 1.5f) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (data.inventory[i][10] == 1)
                {
                    armour.AddComponent<KbAttacked>();
                    armour.GetComponent<KbAttacked>().respondAmount = data.inventory[i][11];
                    armour.GetComponent<WeaponID>().weaponStrength += (data.inventory[i][11] / 1500f) * 0.02f;
                    armourAbilitiesCount++;
                }
                if (data.inventory[i][12] == 1)
                {
                    armour.AddComponent<ThornsArmourTrigger>();
                    armour.GetComponent<ThornsArmourTrigger>().respondPercent = data.inventory[i][13];
                    armour.GetComponent<WeaponID>().weaponStrength += (data.inventory[i][13] / 1f) * 0.02f;
                    armourAbilitiesCount++;
                }
                armour.GetComponent<WeaponID>().weaponStrength += (armourAbilitiesCount * 0.18f);

            }
            else
            {
                Instantiate(tempSlot, InventoryStorage.transform);
            }
        }
    }
}
