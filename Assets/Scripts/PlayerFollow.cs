using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    int cameraUpStage = 0;
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > 5 + 5 * cameraUpStage - 1)
        {
            cameraUpStage += 1;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 5 * cameraUpStage - 1, -10);
        }
        if (player.transform.position.y < -5 + 5 * cameraUpStage)
        {
            cameraUpStage -= 1;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 5 * cameraUpStage, -10);
        }
    }
}
