using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
  public GameObject gameOverPanel;
public GameOver gameOver;
public PlayerMovement playerMovement;
    public SpriteRenderer playerSr;
    public Vector3 respawnPoint;
    public FlamingoBehaviour flamingoBehaviour;

  public PlayerHealth playerHealth;

    public void RespawnNow()
    {
      gameOverPanel.SetActive(false);
      playerHealth.health = playerHealth.maxHealth;
      transform.position = respawnPoint; 
      playerSr.enabled = true;
      playerMovement.enabled = true;
      playerMovement.jumpTrigger = false;
   
      Time.timeScale = 1;
      flamingoBehaviour.deathByFlamingo = false;
      
    }

}


     