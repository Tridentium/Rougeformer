using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {
    public int health = 50;
    public int maxHealthContainer = 100;
    int previous_health;

    public PlayerManagement playerStats;

    public HealthBar healthBar;

    public int moneyGained;
    public int meleeDamage;
    
    public float chargeRange;
    public float chargeColourChangeTime = 0.5f;
    public float maxChargeTime = 4f;
    bool isCharging;
    bool chargeReady;
    bool chargeTimeOut;
    public float chargeEndDistance;
    bool startNormal;

    public float forwardSpeed = 5f;
    public float retreatSpeed = 3f;
    
    public Transform target;
    public float minimumAttackDistance = 0.1f;
    public float minimumRetreatDistance = 4f;
    public float targetDistance = 8;

    public bool isFollowStatus = false;
    public bool isRetreatStatus = false;

    public BoxCollider2D attackHitBox1;
    public BoxCollider2D attackHitBox2;
    public BoxCollider2D targetHitBox;
    public float attackDamage = 5f;
    float timeSinceLastAttack;
    public float attackCooldown;

    public ArmourStats armourStats;

    public int enemyType;
    // An integer to show the enemy type:
    // 0: the basic enemy
    // 1: ranged boi

    private void Start()
    {
        health = (int)Mathf.Floor(Random.Range(maxHealthContainer * 0.2f, maxHealthContainer * 0.4f));
        healthBar.SetMaxHealth(health, maxHealthContainer);
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagement>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        armourStats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArmourStats>();
        targetHitBox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        //Health bar management
        if (health != previous_health)
        {
            healthBar.SetHealth(health, maxHealthContainer);
        }
        previous_health = health;



        //Death Check
        if (health <= 0)
        {
            Incapacitate();
        }

        if (health >= 100)
        {
            Thankful();
        }

        if (gameObject.transform.position.y < -50)
        {
            Incapacitate();
        }



        //Basic enemy behaviours
        if (enemyType == 0)
        {
            if (Vector2.Distance(transform.position, target.position) <= targetDistance)
            {
                if (health >= 20)
                {
                    isFollowStatus = true;
                    isRetreatStatus = false;
                }
                else
                {
                    isFollowStatus = false;
                    isRetreatStatus = true;
                }
                if (isFollowStatus)
                {
                    if (transform.position.x - target.position.x < 0 || target.position.x - transform.position.x < 0)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, target.position, forwardSpeed * Time.deltaTime);
                    }

                }

                if (isRetreatStatus)
                {
                    if (Vector2.Distance(transform.position, target.position) < minimumRetreatDistance)
                        transform.position = Vector2.MoveTowards(transform.position, target.position, -retreatSpeed * Time.deltaTime);
                }
            }
            else
            {
                isFollowStatus = false;
                isRetreatStatus = false;
            }
        }
        else if(enemyType == 1)
        {
            if (Vector2.Distance(transform.position, target.position) < minimumRetreatDistance)
                transform.position = Vector2.MoveTowards(transform.position, target.position, -retreatSpeed * Time.deltaTime);
        }
        else if(enemyType == 2)
        {
            if (Mathf.Abs(playerStats.gameObject.transform.position.x - this.transform.position.x) < chargeRange && (Mathf.Abs(playerStats.gameObject.transform.position.y - this.transform.position.y) < chargeRange / 4) && !isCharging)
            {
                StartCoroutine(chargeScript());
                StartCoroutine(chargeTimer());
                isCharging = true;
            }

            if (chargeReady)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, forwardSpeed * Time.deltaTime * 4);
                if ((Mathf.Abs(playerStats.gameObject.transform.position.x - this.transform.position.x) <  chargeEndDistance && (Mathf.Abs(playerStats.gameObject.transform.position.y - this.transform.position.y) < chargeEndDistance)) || chargeTimeOut)
                {
                    chargeReady = false;
                    startNormal = true;
                }
            }
            if (startNormal)
            {
                if (Vector2.Distance(transform.position, target.position) <= targetDistance)
                {
                    if (health >= maxHealthContainer * 0.2)
                    {
                        isFollowStatus = true;
                        isRetreatStatus = false;
                    }
                    else
                    {
                        isFollowStatus = false;
                        isRetreatStatus = true;
                    }
                    if (isFollowStatus)
                    {
                        if (transform.position.x - target.position.x < 0 || target.position.x - transform.position.x < 0)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, target.position, forwardSpeed * Time.deltaTime);
                        }

                    }

                    if (isRetreatStatus)
                    {
                        if (Vector2.Distance(transform.position, target.position) < minimumRetreatDistance)
                            transform.position = Vector2.MoveTowards(transform.position, target.position, -retreatSpeed * Time.deltaTime);
                    }
                }
            }
        }


        //Enemy Attacks
        if(Time.time > timeSinceLastAttack + attackCooldown)
        {
            if (attackHitBox1.IsTouching(targetHitBox)) 
            {
                Vector2 attackForce = new Vector2(-((attackDamage * (playerStats.playerHealth + 1)) * (1 - Mathf.Clamp(armourStats.kbResistance, 0f, 0.95f)))*3, 200);
                targetHitBox.gameObject.GetComponent<Rigidbody2D>().AddForce(attackForce);
                playerStats.playerHealth += meleeDamage;
                playerStats.attacker = this.gameObject;
                playerStats.damageTaken = meleeDamage;
                timeSinceLastAttack = Time.time;
            }
            if (attackHitBox2.IsTouching(targetHitBox))
            {
                Vector2 attackForce = new Vector2(((attackDamage * (playerStats.playerHealth + 1)) * (1 - Mathf.Clamp(armourStats.kbResistance, 0f, 0.95f))) * 3, 200);
                targetHitBox.gameObject.GetComponent<Rigidbody2D>().AddForce(attackForce);
                playerStats.playerHealth += meleeDamage;
                playerStats.attacker = this.gameObject;
                playerStats.damageTaken = meleeDamage;
                timeSinceLastAttack = Time.time;
            }
        }

    }

    //Other basic enemy behaviour functions

    //Enemy Status Functions
    void Incapacitate()
    {
        playerStats.levelCurrency += moneyGained;
        Destroy(gameObject);
    }

    void Thankful()
    {
        playerStats.levelCurrency += moneyGained * 2;
        Destroy(gameObject);
    }

    IEnumerator chargeScript()
    {
        SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
        renderer.color = new Color(1f, 0.9f, 0.9f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.8f, 0.8f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.7f, 0.7f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.6f, 0.6f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.5f, 0.5f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.4f, 0.4f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.3f, 0.3f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.2f, 0.1f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 0.1f, 0.1f, 1f);
        yield return new WaitForSeconds(0.5f);
        renderer.color = new Color(1f, 1f, 1f, 1f);
        chargeReady = true;

    }

    IEnumerator chargeTimer()
    {
        yield return new WaitForSeconds(maxChargeTime);
        chargeTimeOut = true;
    }
}

