using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazePointer : MonoBehaviour
{
    public GameObject crosshair;
    [SerializeField]
    private Image gazeImage;
    public bool startFillingGaze;
    public float time = 1f;


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
        }
    }

    public void fillGaze()
    {
        gazeImage.fillAmount += 1.0f / time * Time.deltaTime;
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
