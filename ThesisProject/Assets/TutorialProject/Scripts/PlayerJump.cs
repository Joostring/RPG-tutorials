using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    Vector3 jump;
    Rigidbody rb;
    float distance;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
        distance = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, distance)) { rb.AddForce(jump * jumpForce, ForceMode.Impulse); }
        }
    }
}
