using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingScript : MonoBehaviour
{
    bool targetFound = false;
    GameObject currentTarget;
    float currentDistance;
    public CircleCollider2D ourCollider;
    public ArmourStats armourStats;
    public float range = 10f;
    public float speed = 1f;
    public int healing = 10;
    public WeaponID weaponID;
    float travelled = 0f;
    // Start is called before the first frame update
    void Start()
    {
        armourStats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArmourStats>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if(Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance <= range)
            {
                if(currentTarget != null)
                {
                    if(Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance < currentDistance)
                    {
                        currentTarget = enemy;
                        currentDistance = Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance;
                        targetFound = true;
                    }
                }
                else
                {
                    currentTarget = enemy;
                    currentDistance = Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance;
                    targetFound = true;
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if(currentTarget == null)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy") != null)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance <= range)
                    {
                        if (currentTarget != null)
                        {
                            if (Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance < currentDistance)
                            {
                                currentTarget = enemy;
                                currentDistance = Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance;
                                targetFound = true;
                            }
                        }
                        else
                        {
                            currentTarget = enemy;
                            currentDistance = Physics2D.Distance(ourCollider, enemy.GetComponent<BoxCollider2D>()).distance;
                            targetFound = true;
                        }

                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }

            if(currentTarget == null)
            {
                Destroy(gameObject);
            }
        }
        if (ourCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                foreach (BoxCollider2D collider in enemy.GetComponents<BoxCollider2D>())
                {
                    if (ourCollider.IsTouching(collider))
                    {
                        enemy.GetComponent<EnemyStats>().health += Mathf.FloorToInt(healing * armourStats.healingBuff * weaponID.tierBuff);
                    }
                }
            }
        }
        if (ourCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Destroy(gameObject);
        }

        if (currentTarget == null)
        {
            Vector3 moveVector = new Vector3(speed * Time.deltaTime, 0, 0);
            gameObject.transform.position += moveVector;
            travelled += speed * Time.deltaTime;
        }
        else
        {
            Vector3 enemyVector = new Vector3(currentTarget.transform.position.x, currentTarget.transform.position.y + 1, currentTarget.transform.position.z);
            Vector3 moveVector = Vector3.MoveTowards(gameObject.transform.position, enemyVector, speed * Time.deltaTime);
            gameObject.transform.position = moveVector;
            travelled += speed * Time.deltaTime;
        }
        if (travelled > range)
        {
            Destroy(gameObject);
        }
    }
}
