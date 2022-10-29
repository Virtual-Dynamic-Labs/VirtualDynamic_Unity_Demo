using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float verticalVelocity;
    private float groundedTimer;        // to allow jumping when going down ramps
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = 9.81f;

    private void Start()
    {
        // always add a controller
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        controller.center.Set(0f, 1.07f, 0f);

        if (groundedPlayer)
        {
            // cooldown interval to allow reliable jumping even whem coming down ramps
            groundedTimer = 0.2f;
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }

        // slam into the ground
        if (groundedPlayer && verticalVelocity < 0)
        {
            // hit ground
            verticalVelocity = 0f;
        }

        // apply gravity always, to let us track down ramps properly
        verticalVelocity -= gravityValue * Time.deltaTime;

        // gather lateral input control
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // scale by speed
        move *= playerSpeed;

        // only align to motion if we are providing enough input
        if (move.magnitude > 0.05f)
        {
            gameObject.transform.forward = move;
        }

        // allow jump as long as the player is on the ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // must have been grounded recently to allow jump
            if (groundedTimer > 0)
            {
                // no more until we recontact ground
                groundedTimer = 0;

                // Physics dynamics formula for calculating jump up velocity based on height and gravity
                verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravityValue);
            }
        }

        // inject Y velocity before we use it
        move.y = verticalVelocity;

        // call .Move() once only
        controller.Move(move * Time.deltaTime);
    }
}
