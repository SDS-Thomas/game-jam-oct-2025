using UnityEngine;

/**
  * This ensures that this core component isn't accidentally detached
  * BoxCollider2D: Used for collisions
  */
[RequireComponent (typeof(BoxCollider2D))]
public class PlatformController : MonoBehaviour
{
    // public BoxCollider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // https://docs.unity3d.com/ScriptReference/Collider2D.OnCollisionEnter2D.html
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with platform detected!");
    }
}
