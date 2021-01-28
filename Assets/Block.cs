using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
     {
        if (other.collider.CompareTag("Ball")) 
        {
            GameManager.Instance.CheckBlocks();
         Destroy(gameObject);   
        }
            
        
    }
}