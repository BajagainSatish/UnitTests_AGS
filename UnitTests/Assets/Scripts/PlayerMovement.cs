using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    float deltaTime;
    float x, z;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        MyInput();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        deltaTime = Time.deltaTime;
    }
    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f,ForceMode.Force);

        //Player movement
        //x = horizontalInput * moveSpeed * Time.deltaTime;
        //z = verticalInput * moveSpeed * Time.deltaTime;
        //transform.position += new Vector3(x, 0, z);

        //Player movement
        transform.position += CalculateMovement(moveSpeed,horizontalInput,verticalInput,deltaTime);
    }
    public Vector3 CalculateMovement(float speed, float hor, float ver, float delTime)
    {
        x = hor * speed * delTime;
        z = ver * speed * delTime;
        return new Vector3(x,0,z);
    }
}
