using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWallTravel : MonoBehaviour
{
    public float range = 100f;
    public float speed = 1f;
    public int damage = 10;
    float hasTravelled;
    float lastTime;
    public float cooldown = 0.5f;
    public ArmourStats armourStats;
    public BoxCollider2D attackHitbox;
    public WeaponID weaponID;

    bool playerFlipped = false;
    Vector3 moveVector;

    PlayerControllerAnimator characterController;

    private void Start()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerAnimator>();
        armourStats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArmourStats>();
        if (characterController._isFlipped)
        {
            playerFlipped = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private void Update()
    {
        if (!playerFlipped)
        {
            moveVector = new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            moveVector = new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        transform.position += moveVector;
        hasTravelled += speed * Time.deltaTime;
        if (hasTravelled >= range)
        {
            Destroy(gameObject);
        }
        if (attackHitbox.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            if (Time.time > lastTime)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (attackHitbox.IsTouching(enemy.GetComponent<BoxCollider2D>()))
                    {
                        enemy.GetComponent<EnemyStats>().health -= Mathf.FloorToInt(damage * armourStats.damageBuff * weaponID.tierBuff);
                        Vector2 attackForce = new Vector2(1000, 2000);
                        enemy.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(attackForce);
                        lastTime = Time.time + cooldown;
                    }
                }
            }
        }
    }
}


