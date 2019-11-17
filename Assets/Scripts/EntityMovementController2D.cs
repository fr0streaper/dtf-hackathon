using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovementController2D : MonoBehaviour
{
    public LayerMask whatIsSolid;
    public float movementSmoothing = 0.05f;
    public float touchDetectionRadius = 0.1f;

    public Transform groundCheck;
    public Transform ceilingCheck;
    public Transform wallCheck;
    public Transform edgeCheck;

    [System.NonSerialized] public bool isOnGround = false;
    [System.NonSerialized] public bool isAgainstCeiling = false;
    [System.NonSerialized] public bool isOnEdge = false;
    [System.NonSerialized] public bool isAgainstWall = false;

    private Rigidbody2D rigidBody;
    private bool isFacingRight = true;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    private bool TouchCheck(Vector2 point)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, touchDetectionRadius, whatIsSolid);
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
        isOnEdge = !TouchCheck(edgeCheck.position);
        isAgainstWall = TouchCheck(wallCheck.position);
    }

    public void Move(Vector2 delta, bool ignoreX = false, bool ignoreY = false)
    {
        Vector3 targetVelocity = new Vector2(delta.x, delta.y);

        if (ignoreX)
        {
            targetVelocity.x = rigidBody.velocity.x;
        }
        if (ignoreY)
        {
            targetVelocity.y = rigidBody.velocity.y;
        }

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

    public void MoveTo(Vector3 point)
    {
        rigidBody.transform.position = point;
    }

    void HorizontalFlip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
