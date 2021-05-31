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
    public bool startFillingGaze;
    [HideInInspector]
    public bool fillingCompleted = false;
    private float time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        deactivateCrosshair();
        gazeImage.fillAmount = 0;
        startFillingGaze = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFillingGaze)
        {
            fillGaze();
        } else 
        {
            gazeImage.fillAmount = 0;
            fillingCompleted = false;
        }
    }

    public void fillGaze()
    {
        if (gazeImage.fillAmount == 1.0f) {
            startFillingGaze = false;
            fillingCompleted = true;
        } else {
            gazeImage.fillAmount += 1.0f / time * Time.deltaTime;
        }
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
