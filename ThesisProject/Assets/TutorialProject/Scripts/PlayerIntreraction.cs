using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IInteractable
{
    void Interact();
}
public class PlayerIntreraction : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] float interactRange;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
    }
    

    private void OnInteraction(InputValue input)
    {
        Debug.Log("Interacting");
        
        Ray ray = new Ray
        {
            origin = playerCam.transform.position,
            direction = playerCam.transform.forward,
        };

        Debug.DrawRay(ray.origin, ray.direction * interactRange);

        RaycastHit rayHit;

        if (Physics.Raycast(ray, out rayHit, interactRange))
        {
            IInteractable interactable = rayHit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }

       
    }
}


