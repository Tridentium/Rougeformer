using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsArmourTrigger : MonoBehaviour
{
    public ArmourStats armourStats;
    public float respondPercent = 0;
    public PlayerManagement player;
    int previousPlayerHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagement>();
        armourStats = this.transform.parent.GetComponent<ArmourStats>();
        previousPlayerHealth = player.playerHealth;
    }
    void Update()
    {
        if(this.transform.GetSiblingIndex() < 3 && this.transform.parent.tag == "InventoryStorage")
        {
            if (previousPlayerHealth < player.playerHealth)
            {
                armourStats.Thorns(respondPercent);
                previousPlayerHealth = player.playerHealth;
            }
        }
    }
}
