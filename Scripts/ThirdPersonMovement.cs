using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float playerSpeed;

    public Rigidbody rb;

    public float jumpForce = 4;

    public Animator anim;

    public CapsuleCollider playerCollider;
    // Update is called once per frame
    void Update()
    {
        //Every update frame, get information about what is currently being pressed. (Axis buttons found in Unity->Edit->Project Settings->Input Manager)
        Movement();
        Jump();
    }

    private void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(vec, Space.Self);
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void Jump()
    {
        bool jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (jumpKeyPressed && isGrounded())
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            jumpVector.x = rb.velocity.x;
            jumpVector.z = rb.velocity.z;
            rb.velocity = jumpVector;
        }
    }

    private bool isGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.1f);
        return isGrounded;
    }
}
