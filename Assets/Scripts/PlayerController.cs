using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


[RequireComponent (typeof(Rigidbody2D))]
// https://www.youtube.com/watch?v=T8fG0D2_V5M&list=PL7S-IAgf3dlUPT3iheJaUWu-Johr8bgCk&index=2
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update ()
    {
        if(InputManager.instance.isLeft) {
            transform.position -=  new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
        if(InputManager.instance.isRight) {
            transform.position +=  new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
        if(InputManager.instance.isJump) {
            Debug.Log("Jump!");
        }
    }

}
