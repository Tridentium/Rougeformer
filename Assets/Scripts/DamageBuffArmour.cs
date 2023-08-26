 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuffArmour : MonoBehaviour
{
    public PlayerManagement player;
    public ArmourStats armourStats;
    public float buff;
    public float buffTime;
    int previousPlayerHealth;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagement>();
        armourStats = this.transform.parent.GetComponent<ArmourStats>();
        previousPlayerHealth = player.playerHealth;
    }
    void Update()
    {
        if (this.transform.GetSiblingIndex() < 3 && this.transform.parent.tag == "InventoryStorage")
        {
            if (previousPlayerHealth < player.playerHealth)
            {
                StartCoroutine(damageBuffApplied());
                previousPlayerHealth = player.playerHealth;
            }
        }
    }
    IEnumerator damageBuffApplied()
    {
        armourStats.damageBuff += buff;
        yield return new WaitForSeconds(buffTime);
        armourStats.damageBuff -= buff;
    }
}
