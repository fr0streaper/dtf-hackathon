using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyController2D : MonoBehaviour
{
    public EntityMovementController2D movementController;
    public float speedX = 2f;
    public float speedBoost = 1f;

    [System.NonSerialized] public bool isAggressive = false;

    public Transform player;
    void Die()
    {
        movementController.enabled = false;
        this.enabled = false;
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform; 
    }

    void Update()
    {
        if (movementController.isAgainstWall || movementController.isOnEdge)
        {
            speedX = -speedX;
        }            
    }

    private void FixedUpdate()
    {
        if (!isAggressive)
        {
            movementController.Move(new Vector2(speedX, 0f) * speedBoost);
        }
    }
}
