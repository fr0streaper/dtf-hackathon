using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController2D : MonoBehaviour
{
    public EntityMovementController2D movementController;
    public float speedX = 10f;
    public float jumpStartingSpeed = 40f;
    public float speedBoost = 20f;

    private Vector2 speed = Vector2.zero;
    private bool jump = false;

    IEnumerator JumpCoroutine()
    {
        Debug.Log("Started Jump coroutine");

        float targetSpeedY = 0f;
        speed.y = jumpStartingSpeed;

        yield return new WaitForFixedUpdate();
        while (Mathf.Abs(speed.y - targetSpeedY) > 0.05f)
        {
            speed.y = Mathf.Lerp(speed.y, targetSpeedY, 0.25f);

            Debug.Log(string.Format("Lerped vertical speed, current value {0} moving to {1}", speed.y, targetSpeedY));

            if (movementController.isAgainstCeiling)
            {
                break;
            }

            yield return new WaitForFixedUpdate();
        }

        speed.y = 0;
    }

    void Update()
    {
        speed.x = Input.GetAxisRaw("Horizontal") * speedX;

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
            StartCoroutine(JumpCoroutine());
        }

        movementController.Move(speed * Time.fixedDeltaTime * speedBoost);
    }
}
