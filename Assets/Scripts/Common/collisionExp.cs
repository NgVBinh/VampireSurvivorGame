using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionExp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.gameObject.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.IncreaseExp(1);
                Destroy(gameObject);
            }
        }
    }
}
