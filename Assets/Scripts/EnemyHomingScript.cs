using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingScript : MonoBehaviour
{
    GameObject currentTarget;
    float currentDistance;
    public CircleCollider2D ourCollider;
    public float range = 10f;
    public float speed = 1f;
    public int healing = 10;
    float travelled = 0f;

    Vector3 moveVector;
    Vector3 newVector;

    public BoxCollider2D playerBox;
    public PlayerManagement player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagement>();
        playerBox = player.GetComponent<BoxCollider2D>();
        currentTarget = player.gameObject;
        Vector3 enemyVector = new Vector3(currentTarget.transform.position.x, currentTarget.transform.position.y + 0.5f, currentTarget.transform.position.z);
        if (Mathf.Abs(Vector2.Distance(new Vector2(currentTarget.transform.position.x, 0), new Vector2(this.transform.position.x, 0))) > range || Mathf.Abs((Vector2.Distance(new Vector2(currentTarget.transform.position.y, 0), new Vector2(this.transform.position.y, 0)))) > range / 2)
        {
            Destroy(this.gameObject);
        }
        moveVector = Vector3.MoveTowards(gameObject.transform.position, enemyVector, speed * Time.deltaTime);
        newVector = moveVector - this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
        if (ourCollider.IsTouching(playerBox))
        {
            player.playerHealth += 2;
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
            gameObject.transform.position += newVector;
            travelled += speed * Time.deltaTime;
        }
        if (travelled > range)
        {
            Destroy(gameObject);
        }
    }
}
