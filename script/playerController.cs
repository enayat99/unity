using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private const float LANE_DISTANCE = 3.5f;
    private const float TURN_SPEED = 0.05F;
    private CharacterController controller;
    float jumpForce = 4.0f;
    float gravity = 12.0f;
    float verticalvelocity;
    public float speed = 8.0f;
    int desiredLand = 1; //0 left 1=middle, 2=right



    private Animator anim;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        if (inputController.Instance.SwipeLeft)
            MoveLane(false);
        if (inputController.Instance.SwipeRight)
            MoveLane(true);

        //calculate where we should be in future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLand == 0)
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if (desiredLand == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;
        //calculate our move delta

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        bool isGrounded = IsGrounded();
        anim.SetBool("isRuning", isGrounded);

        if (isGrounded)
        {
            verticalvelocity = -0.1f;
            if (inputController.Instance.SwipeUp)
            {
                anim.SetTrigger("isJumping");
                verticalvelocity = jumpForce;
            }
            else
            {
                verticalvelocity -= (gravity * Time.deltaTime);
                //fast falling 
                if (inputController.Instance.SwipeDown)
                {
                    verticalvelocity = -jumpForce;
                }
            }
        }
        moveVector.y = verticalvelocity;
        moveVector.z = speed;

        //move the player

        controller.Move(moveVector * Time.deltaTime);
        //Rotate player
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }

    }

    private void MoveLane(bool goingRight)
    {

        desiredLand += (goingRight) ? 1 : -1;
        desiredLand = Mathf.Clamp(desiredLand, 0, 2);


        /*if (!goingRight)
          {
              desiredLand--;
              if (desiredLand == -1)
                  desiredLand = 0;
          }
          else
          {
              desiredLand++;
              if (desiredLand == 3)
                  desiredLand = 2;
          }*/


    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(
        new Vector3(controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents
        .y) + 0.2f, controller.bounds.center.z), Vector3.down);
        return true;
    }


    //destroy gamgeobject


}

