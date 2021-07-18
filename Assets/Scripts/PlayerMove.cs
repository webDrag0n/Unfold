using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{

    public float speed;

    private float horizontal;
    private float vertical;

    public bool grabbed = false;

    private float gravity = -9.8f;

    private CharacterController controller;
    public Transform camera_transform;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = 0;
        vertical = 0;

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = -Input.GetAxisRaw("Horizontal");
        vertical = -Input.GetAxisRaw("Vertical");
        
        if (controller.isGrounded)
        {
            controller.Move(new Vector3(horizontal, 0, vertical) * speed);
        }
        else
        {
            controller.Move(new Vector3(horizontal, gravity, vertical) * speed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            grabbed = !grabbed;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "grabbable")
        {
            if (grabbed)
            {
                collision.transform.parent = transform;
            }
            else
            {
                collision.transform.parent = transform.parent;
            }
        }
        
    }
}
