using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

/**
  * This ensures that this core component isn't accidentally detached
  * Rigidbody2D: Used for Physics, specifically gravity and momemntum transfer on collision
  * BoxCollider2D: Used for collisions
  */
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        /**
          * Checks the state on the InputManager singleton and acts accordingly
          */
        if(InputManager.instance.isLeft) {
            transform.position -=  new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        } else if(InputManager.instance.isRight) {
            transform.position +=  new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
        if(InputManager.instance.isJump) {
            Debug.Log("Jump!");
        }
    }
}
