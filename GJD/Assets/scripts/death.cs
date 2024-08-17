using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    PlayerMove playerMove;
    public Collider2D coll;
    private bool hasTriggered = false; // New flag to prevent multiple triggers

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return; // If it has already been triggered, exit early

        if (collision.tag == "Player" && playerMove.health <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.tag == "Player" && playerMove.health > 1)
        {
            playerMove.returnplayertocheckpoint();
            coll.enabled = false;
            hasTriggered = true; // Set the flag to true
            Invoke("enableCollider", 1); // Delay before enabling the collider again
        }
    }

    private void enableCollider()
    {
        coll.enabled = true;
        hasTriggered = false; // Reset the flag so the trigger can be used again
    }
}
