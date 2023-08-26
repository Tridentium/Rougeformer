using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public BoxCollider2D Collider;
    public BoxCollider2D playerBox;
    public GameObject hoverText;
    public PlayerManagement player;
    bool isPlayerThere = false;
    private void Update()
    {
        if (Collider.IsTouching(playerBox))
        {
            isPlayerThere = true;
        }
        else
        {
            isPlayerThere = false;
        }
        if (isPlayerThere)
        {
            hoverText.SetActive(true);
        }
        else
        {
            hoverText.SetActive(false);
        }
        if (isPlayerThere && Input.GetKeyDown(KeyCode.P))
        {
            player.SavePlayer();
            SceneManager.LoadScene(1);
        }
    }
}
