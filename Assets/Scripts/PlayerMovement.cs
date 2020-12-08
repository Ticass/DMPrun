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

     private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05f){
            anim.SetBool("IsRunning", true);
        } else {
            anim.SetBool("IsRunning", false);
        }

        anim.SetBool("IsGrounded", IsGrounded());
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

}
