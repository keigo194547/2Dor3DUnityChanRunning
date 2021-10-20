using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 movedir = Vector3.zero;


    public float speedX;
    public float speedZ;
    public float acceleratorZ;

    private const string isRun = "isRunning";
    private const string isJump = "isJumping";


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if (controller.isGrounded) {
            if (Input.GetKeyDown("space"))
            {

                if (controller.isGrounded)
                {
                    movedir.y = 10f;
                }
            }
            else
            {
                animator.SetBool(isJump, false);
            }
        }
        

        movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, speedZ);

        if (movedir.z >= 0.1)
        {
            animator.SetBool(isRun, true);
        }


        movedir.y -= 20f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.y = 0;
        }
    }
}