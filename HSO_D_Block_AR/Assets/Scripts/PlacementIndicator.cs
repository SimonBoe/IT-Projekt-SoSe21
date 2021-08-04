using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject startOverlay;
    private ARRaycastManager rayManager;
    private GameObject visualIndicator;
    private GazePointer gazePointer;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        startOverlay.SetActive(false);
        // get components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visualIndicator = GameObject.FindGameObjectWithTag("visualIndicator");

        // show the visual indicator
        visualIndicator.SetActive(true);

        // Get a reference to the UIManager and subscribe to OnClicked event
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.OnClicked += UiManager_OnClicked;
    }

    private void UiManager_OnClicked()
    {
        if (!visualIndicator.activeInHierarchy)
        {
            visualIndicator.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // shoot a raycast from center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon);

        // if you hit an AR plane, update the position and rotation
        if (hits.Count > 0 && visualIndicator.activeInHierarchy)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
