using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // ==========================================
    
    
    public float variableA = 7.0f;
    public float variableB = 150.0f;
    public float variableC = 20.0f;
    public float variableD = 1.0f;
    public float variableE = 10.0f;


    // ==========================================


    private Animator anim;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private bool isJumpingUp = false;
    private float jumpHeight = 0.5f;
    private float jumpStartHeight = 0.0f;

    void Start ()
    {
        controller = GetComponent <CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update ()
    {
        transform.localScale = new Vector3(variableE, variableE, variableE);

        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetInteger ("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger ("AnimationPar", 0);
        }
        
        if(controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * variableA;

            if (Input.GetAxis("Jump") > 0.0f)
            {
                isJumpingUp = true;
                jumpStartHeight = transform.position.y;
            }
        }
        

        if (isJumpingUp)
        {
            if (transform.position.y < jumpHeight + jumpStartHeight)
            {
                moveDirection += transform.up * variableD;
            }
            else
            {
                isJumpingUp = false;
            }
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * variableB * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= variableC * Time.deltaTime;
    }
}
