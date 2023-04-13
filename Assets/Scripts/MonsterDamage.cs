using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public int damage;
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //check if it was the player who collided
      if(collision.gameObject.tag == "Player")
      {
        //tells script to look in the playerHealth script, then TakeDamage function
        playerHealth.TakeDamage(damage);
      }
    }
}
