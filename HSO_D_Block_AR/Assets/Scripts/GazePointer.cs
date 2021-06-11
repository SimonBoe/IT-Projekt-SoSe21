using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazePointer : MonoBehaviour
{
    public GameObject crosshair;
    [SerializeField]
    private Image gazeImage;
    [HideInInspector]
    public bool IsFilling;
    [HideInInspector]
    public bool fillingCompleted = false;
    private float time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        deactivateCrosshair();
        gazeImage.fillAmount = 0;
        IsFilling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFilling)
        {
            fillGaze();
        } 
    }

    public void fillGaze()
    {
        if (gazeImage.fillAmount == 1.0f) {
            IsFilling = false;
            fillingCompleted = true;
        } else {
            gazeImage.fillAmount += 1.0f / time * Time.deltaTime;
        }
    }

    public void reset() {
        gazeImage.fillAmount = 0;
        IsFilling = false;
        fillingCompleted = false;
    }

    public void activateCrosshair()
    {
        crosshair.SetActive(true);
        Debug.Log(crosshair.name + " has been activated");
    }

    public void deactivateCrosshair()
    {
        crosshair.SetActive(false);
        Debug.Log(crosshair.name + " has been deactivated");
    }
}
