using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullets : MonoBehaviour
{



 public GameObject diePEffect;
 public GameObject Bullet;
   

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.name == "BulletCheck"){
            Destroy(gameObject, 3);
        }
    }


    void Die(){
        if (diePEffect != null){
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
