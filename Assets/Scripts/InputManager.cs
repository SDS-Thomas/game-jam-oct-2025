using UnityEngine;
// https://docs.unity3d.com/ScriptReference/Input.html
public class InputManager : MonoBehaviour
{
    /** 
      * This uses the Singleton pattern: https://en.wikipedia.org/wiki/Singleton_pattern
      * This ensures that we can easily access the object and it's associated data from anywhere
      */
    public static InputManager instance { get; set; }

    [Header("Keyboard Controls")]
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;

    [Header("Keyboard State")]
    public bool isLeft = false;
    public bool isRight = false;
    public bool isJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /**
          * Assigns a True/False value to each of these keys and their associated actions
          */
        isLeft = Input.GetKey(left);
        isRight = Input.GetKey(right);
        isJump = Input.GetKey(jump);
    }

    private void Awake()
    {
        /**
          * Sets the current object ("this") to the static "instance" variable so that this instance
          * can be easily accessed
          */
        DontDestroyOnLoad(this);
        instance = this;
    }
}
