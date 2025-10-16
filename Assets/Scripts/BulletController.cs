using UnityEngine;
// https://docs.unity3d.com/ScriptReference/CircleCollider2D.html

[RequireComponent (typeof(CircleCollider2D))]
public class BulletController : MonoBehaviour
{
    public float velocity = 0.0001f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Bullet Created");   
    }

    // Update is called once per frame
    void Update()
    {
        /**
          * Adjust the position every frame based on the direction the bullet is facing
          */
        transform.position += velocity * Time.deltaTime * transform.up;   
    }

    // https://docs.unity3d.com/ScriptReference/Collider2D.OnCollisionEnter2D.html
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Bullet collision detected!");
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
