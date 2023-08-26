using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourStats : MonoBehaviour
{
    public float damageBuff = 1;
    public float healingBuff = 1;
    public float kbResistance = 1;

    public PlayerManagement player;
    public void Thorns (float respondPercentage)
    {
        player.attacker.GetComponent<EnemyStats>().health -= Mathf.FloorToInt(respondPercentage * player.damageTaken * 10);

    }

    public void KbRespond(float kbAmount)
    {
        Vector2 attackForce = new Vector2(kbAmount, kbAmount * 2);
        player.attacker.GetComponent<Rigidbody2D>().AddRelativeForce(attackForce);

    }
}
