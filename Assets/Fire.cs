using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour 
{
    [SerializeField]
    private float damage = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Debug.Log("Player hit points: " + player.CurrentHitpoints);
        }
    }
}
