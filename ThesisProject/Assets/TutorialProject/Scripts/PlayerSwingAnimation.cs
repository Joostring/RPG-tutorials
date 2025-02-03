using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwingAnimation : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
   

    private void OnAttack(InputValue input)
    {
        Debug.Log("swinging");
        if (animator != null && playerMovement.movementVector == Vector3.zero && !animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
        {
            animator.SetTrigger("isSwinging");
        }
        
    }
}
