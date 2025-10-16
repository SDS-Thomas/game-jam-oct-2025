using UnityEngine;

public class LauncherController : MonoBehaviour
{
    /**
      * This is linked in the UI. It uses this to know how to create a bullet object
      */
    public TriggerController triggerController;
    public BarrelController barrelController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        triggerController = transform.Find("Trigger").gameObject.GetComponent<TriggerController>();
        triggerController.RegisterLauncher(this);

        barrelController = transform.Find("Barrel").gameObject.GetComponent<BarrelController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollision()
    {
        Debug.Log("Launcher OnCollision");
        barrelController.Shoot();
    }
}
