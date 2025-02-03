using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    Vector3 movementInput;
    public Vector3 movementVector;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
       

    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
        
    }

    public void OnMovement(InputValue input) 
    {
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
        animator.SetBool("isMoving", true); 
    }

    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
        animator.SetBool("isMoving", false);
    }

    private void OnJump(InputValue input)
    {
        characterRB.velocity = new Vector3(0, jumpPower, 0) * (float)Time.fixedDeltaTime;
    }

    private void OnCrouch(InputValue input)
    {
        movementSpeed /= 2;
    }
    private void OnCrouchStop(InputValue input)
    {
        movementSpeed = 150;
    }

    private void OnSprint(InputValue input)
    {
        movementSpeed *= 1.5f;
    }

    private void OnSprintStop(InputValue input)
    {
        movementSpeed = 150;
    }

    private void ApplyMovement()
    {
        if (movementInput != Vector3.zero)
        {
            //movementVector = movementInput.x * transform.right + movementInput.z * transform.forward;
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
            movementVector.y = 0;

            

            characterRB.velocity = (movementVector * (float)Time.fixedDeltaTime * movementSpeed);
        }
    }
}
