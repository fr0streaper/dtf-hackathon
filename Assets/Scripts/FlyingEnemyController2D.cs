using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController2D : MonoBehaviour
{
    public EntityMovementController2D movementController;
    public float speedY = 2f;
    public float speedBoost = 1f;
    public float chaseSpeed = 2f;
    public bool isAggressive = false;

    private Transform player;

    void Die()
    {
        movementController.enabled = false;
        this.enabled = false;
    }    

    private void Start()
    {
        movementController = GetComponent<EntityMovementController2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAggressive && 
            (movementController.isAgainstCeiling && speedY > 0 || movementController.isOnGround && speedY < 0))
        {
            speedY = -speedY;
        }
    }

    private void FixedUpdate()
    {
        if (!isAggressive)
        {
            movementController.Move(new Vector2(0f, speedY) * speedBoost);
        }
        else
        {
            movementController.Move(Vector2.zero);

            if(player)
            { 
                Vector2 targetPoint = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.fixedDeltaTime * speedBoost);
                movementController.MoveTo(targetPoint);
            }
        }
    }
}
