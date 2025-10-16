using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerController : MonoBehaviour
{
    public LauncherController launcher;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterLauncher(LauncherController lnchr)
    {
        launcher = lnchr;
    }

    // https://docs.unity3d.com/ScriptReference/Collider2D.OnCollisionEnter2D.html
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Trigger OnCollisionEnter2D");
        launcher.OnCollision();
    }
}
