﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_with_keyboard : MonoBehaviour
{
    public float speed = 4.0f;

    public float jumpSpeed = 4.5f;

    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.forward;

    private CharacterController controller;

	// Use this for initialization
	void Start ()
	{
	    controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (controller.isGrounded)
	    {
	        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	        moveDirection = transform.TransformDirection(moveDirection);
	        moveDirection *= speed;
	        if (Input.GetButton("Jump"))
	            moveDirection.y = jumpSpeed;
	    }
	    moveDirection.y -= gravity * Time.deltaTime;
	    controller.Move(moveDirection * Time.deltaTime);
    }
}


