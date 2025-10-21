using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySequenceScript : MonoBehaviour
{
    [SerializeField] private GameObject uiImage;
    [SerializeField] private int nextSceneIndex;
    private Image image;

    [SerializeField] private List<Sprite> slides;
    [SerializeField] private float autoContinueDelay;

    private float autoContinueTimer = 0;
    private InputAction nextAction;
    private bool isClicked = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = uiImage.GetComponent<Image>();
        nextAction = InputSystem.actions.FindAction("Player/Attack");
        ToNextSlide();
    }

    // Update is called once per frame
    void Update()
    {
        bool clicking = nextAction.ReadValue<float>() > 0.1f;
        if ((clicking && !isClicked) || autoContinueTimer > autoContinueDelay)
        {
            ToNextSlide();
            isClicked = true;
        }
        if (!clicking)
            isClicked = false;

        autoContinueTimer += Time.deltaTime;
    }
    
    void ToNextSlide()
    {
        if (slides.Count == 0)
        {
            SceneManager.LoadScene(nextSceneIndex);
            return;
        }
        
        Sprite slide = slides[0];
        slides.RemoveAt(0);
        image.sprite = slide;

        autoContinueTimer = 0;
    }
}
