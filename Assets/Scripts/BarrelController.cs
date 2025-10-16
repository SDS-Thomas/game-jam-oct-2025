using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
  * Creates a prefab at the barrel location
  * https://docs.unity3d.com/6000.2/Documentation/Manual/Prefabs.html
  */
public class BarrelController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int numAmmo = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (numAmmo <= 0) 
        {
            Debug.Log("Out of Ammo!");
            return;
        }
        numAmmo -= 1;
        Debug.Log("Shoot!");

        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;

        /**
          * Set the rotation of the bullet so that it matches the rotation of the barrel
          */
        bullet.transform.rotation = transform.rotation;
    }
}
