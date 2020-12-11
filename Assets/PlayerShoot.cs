using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool isShooting;
    public float shootSpeed, shootTimer;
    public Transform Shootpos;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting){
            StartCoroutine(Shoot());
            
        }
    }

    int direction( ){
        if(transform.localScale.x < 0f) {
            return -1;
        } else {
            return +1;
        }
    }


        
    

    IEnumerator Shoot(){
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, Shootpos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        Destroy(newBullet, 2);
    }
}
