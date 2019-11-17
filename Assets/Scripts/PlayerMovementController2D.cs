using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController2D : MonoBehaviour
{
    public EntityMovementController2D movementController;
    public float speedX = 10f;
    public float jumpForce = 20f;
    public float speedBoost = 20f;

    private Vector2 speed = Vector2.zero;
    private bool jump = false;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 12);
        Physics2D.IgnoreLayerCollision(9, 11);
    }

    void Update()
    {
        speed.x = Input.GetAxisRaw("Horizontal") * speedX * speedBoost;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (jump && movementController.isOnGround)
        {
            jump = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        movementController.Move(speed * Time.fixedDeltaTime, false, true);
    }
}
