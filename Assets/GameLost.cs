using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLost : MonoBehaviour
{
   public GameObject lostGame;
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Ball"))
       {
//Time.timeScale = 0f;
       lostGame.SetActive(true);
       }
       
    }
}
