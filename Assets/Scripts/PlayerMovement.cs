using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//pluralsight.com tutorial was followed in the commented code below.
public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed;
    public int walkSpeed;
    public int runSpeed;

    private Vector3 input;
    private Vector3 moveDirection;
    private Vector3 velocity;

    private Camera mainCamera;
    private Animator animator;
    private CharacterController charController;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Animate();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = velocity;
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        input = new Vector3(horizontal, 0, vertical);
        
        input.Normalize();

        if (input.magnitude > 0) {
            transform.rotation = Quaternion.LookRotation(input);
        }

        velocity = input * playerSpeed;
    }

    private void Animate()
    {
        animator.SetFloat("blendSpeed", rigidBody.velocity.magnitude);
    }

    //private void Move()
    //{
    //    float horizontal = Input.GetAxisRaw("Horizontal");
    //    float vertical = Input.GetAxisRaw("Vertical");

    //    input = new Vector3(horizontal, 0, vertical);
    //    input.Normalize();

    //    Vector3 cameraForward = mainCamera.transform.forward;
    //    cameraForward.y = 0;

    //    Quaternion cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
    //    Vector3 lookAt = cameraRelativeRotation * input;

    //    if (input.sqrMagnitude > 0)
    //    {
    //        Ray lookRay = new Ray(transform.position, lookAt);
    //        transform.LookAt(lookRay.GetPoint(1));
    //    }

    //    velocity = transform.forward * playerSpeed * input.sqrMagnitude;

    //}
}
