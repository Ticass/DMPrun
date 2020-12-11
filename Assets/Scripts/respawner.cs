using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawner : MonoBehaviour
{
   public Transform player;
   public Transform respawnPoint;

   void OnTriggerEnter2D(Collider2D other)
   {
       player.transform.position = respawnPoint.transform.position;
   }
}
