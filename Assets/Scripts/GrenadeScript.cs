using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float timeToExplode;
    public float explosionDuration;
    public float countdown;
    public int healing;
    public float cooldown;
    public WeaponID weaponID;
    public ArmourStats armourStats;
    float lastTime = 0f;
    bool exploded = false;

    public BoxCollider2D explosionCollider;
    public SpriteRenderer spriteRen;
    void Start()
    {
        armourStats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArmourStats>();
        countdown = timeToExplode;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= 1 * Time.deltaTime;
        if(countdown <= 0 && exploded == false)
        {
            StartCoroutine(explode());
            exploded = true;
        }

        if (explosionCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            if (Time.time > lastTime)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (explosionCollider.IsTouching(enemy.GetComponent<BoxCollider2D>()) && exploded)
                    {
                        enemy.GetComponent<EnemyStats>().health += Mathf.FloorToInt(healing * armourStats.healingBuff * weaponID.tierBuff);
                        lastTime = Time.time + cooldown;
                    }
                }
            }
        }
    }

    IEnumerator explode()
    {
        explosionCollider.enabled = true;
        spriteRen.enabled = false;
        yield return new WaitForSeconds(explosionDuration);
        explosionCollider.enabled = false;
        Destroy(gameObject);
    }
}
