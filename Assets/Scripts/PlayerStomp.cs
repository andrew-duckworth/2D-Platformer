using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Weak Point")
      {
        Destroy(collision.gameObject);
      }
    }

    
}
