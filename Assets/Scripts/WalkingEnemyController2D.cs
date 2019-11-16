using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyController2D : MonoBehaviour
{
    public EntityMovementController2D movementController;
    public float speedX = 2f;
    public float speedBoost = 1f;

    void Update()
    {
        if (movementController.isAgainstWall || movementController.isOnEdge)
        {
            speedX = -speedX;
        }            
    }

    private void FixedUpdate()
    {
        movementController.Move(new Vector2(speedX, 0f) * speedBoost);
    }
}
