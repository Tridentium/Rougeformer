using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyPelletSpawner : MonoBehaviour
{
    public GameObject pellet;
    public bool spawnAllowed = false;
    public float cooldown;

    private void Start()
    {
        StartCoroutine(launchPellet());
    }
    private void Update()
    {

        if (spawnAllowed)
        {
            Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
            Instantiate(pellet, newPos, Quaternion.identity);
            spawnAllowed = false;
        }
            
    }

    IEnumerator launchPellet()
    {
        spawnAllowed = true;
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(launchPellet());
    }
}
