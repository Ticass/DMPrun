using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce = 20f;
    public Rigidbody2D rb;
    private float mx;
    public Transform Feet;
    public LayerMask groundLayers;
    public Animator anim;
    public GameObject playerPrefab;
    public float degreesPerSec = 360f;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

       //TurnLeft();
        
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05f){
            anim.SetBool("IsRunning", true);
        } else {
            anim.SetBool("IsRunning", false);
        }

        anim.SetBool("IsGrounded", IsGrounded());

        //keep the player inside the map
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
                                         Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump () {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    public bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(Feet.position, 0.5f, groundLayers);

        if (groundCheck) {
            return true;
        } 
        return false;
    }

    public void TurnLeft(){
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    //keep the player inside the map
    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(.5f, .75f, 0f);
        topRightLimit = topRight + new Vector3(-.5f, -.75f, 0f);
    }
}
