using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    float hMove;
    float vMove;

    float playerHeight = 2f;

    float rbDrag = 6f;



    Vector3 moveDirection;

    Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
       

        controls();
        controlDrag();

       
    }

    void controls()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * vMove + transform.right * hMove;
    }

    

    void controlDrag()
    {
        rigidBody.drag = 6f;
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    void movePlayer()
    {
        rigidBody.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }

}
