using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovementController2D : MonoBehaviour
{
    public LayerMask canWalkOn;
    public Transform groundCheck;
    public Transform ceilingCheck;
    public float movementSmoothing = 0.05f;

    [System.NonSerialized] public bool isOnGround = false;
    [System.NonSerialized] public bool isAgainstCeiling = false;

    private Rigidbody2D rigidBody;
    private bool isFacingRight = true;
    private float touchCheckRadius = 0.1f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private bool TouchCheck(Vector2 point)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, touchCheckRadius, canWalkOn);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return true;
            }
        }

        return false;
    }

    private void FixedUpdate()
    {
        isOnGround = TouchCheck(groundCheck.position);
        isAgainstCeiling = TouchCheck(ceilingCheck.position);
    }

    public void Move(Vector2 delta)
    {
        Vector3 targetVelocity = new Vector2(delta.x, delta.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (delta.x > 0 && !isFacingRight)
        {
            HorizontalFlip();
        }
        else if (delta.x < 0 && isFacingRight)
        {
            HorizontalFlip();
        }
    }

    void HorizontalFlip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
