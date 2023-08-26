using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazarBeamDamage : MonoBehaviour
{
    float lastTime;
    public float cooldown = 0.5f;
    public int damage = 10;
    public BoxCollider2D attackHitbox;
    public ArmourStats armourStats;
    public float survivalTime = 0.3f;
    public WeaponID weaponID;
    float deathTime;
    // Update is called once per frame
    private void Start()
    {
        deathTime = Time.time + survivalTime;
        armourStats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArmourStats>();
    }
    void Update()
    {
        if (attackHitbox.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            if (Time.time > lastTime)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (attackHitbox.IsTouching(enemy.GetComponent<BoxCollider2D>()))
                    {
                        if(enemy.GetComponent<EnemyStats>() != null)
                            enemy.GetComponent<EnemyStats>().health -= Mathf.FloorToInt(damage * armourStats.damageBuff * weaponID.tierBuff);
                        Vector2 attackForce = new Vector2(1000, 2000);
                        enemy.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(attackForce);
                        lastTime = Time.time + cooldown;
                    }
                }
            }
        }
        if (Time.time > deathTime)
        {
            Destroy(gameObject);
        }
    }
}
