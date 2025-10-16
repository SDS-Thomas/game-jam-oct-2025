using UnityEngine;
// https://docs.unity3d.com/ScriptReference/Input.html
public class InputManager : MonoBehaviour
{
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
        KeyboardControls();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }
    
   private void KeyboardControls()
    {
        isLeft = Input.GetKey(left);
        isRight = Input.GetKey(right);
        isJump = Input.GetKey(jump);
    }
}
