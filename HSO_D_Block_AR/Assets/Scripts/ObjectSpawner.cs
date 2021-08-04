using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectSpawner : MonoBehaviour
{
    // in editor select the prefab which is instatiated by tapping the screen
    [SerializeField]
    private GameObject objectToSpawn;

    private GameObject spawnedObject;

    private ARSessionOrigin sessionOrigin;

    private PlacementIndicator placementIndicator;
    private PhysicsRaycastManager PhysicsRaycastManager;
    private GazePointer gazePointer;


    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        PhysicsRaycastManager = FindObjectOfType<PhysicsRaycastManager>();
        PhysicsRaycastManager.gameObject.SetActive(false);
                                
        // Get a reference to the UIManager and subscribe to OnClicked event
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.OnClicked += UiManager_OnClicked;

        sessionOrigin = FindObjectOfType<ARSessionOrigin>();

        gazePointer = GameObject.FindGameObjectWithTag("GazePointer").GetComponent<GazePointer>();
    }

    private void UiManager_OnClicked()
    {
        if (spawnedObject)
        {
            Destroy(spawnedObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check touches
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //instantiate object, if instance of object already exists, destroy object before instantiate new object
            if (!GameObject.FindGameObjectWithTag("objectToSpawn"))
            {
                spawnedObject = Instantiate(objectToSpawn);
                sessionOrigin.MakeContentAppearAt(spawnedObject.transform, placementIndicator.transform.position);
                GameObject.FindGameObjectWithTag("visualIndicator").SetActive(false);
                PhysicsRaycastManager.gameObject.SetActive(true);
                gazePointer.activateCrosshair();
            }
            else
            {
                return;
            }
        }
    }
}
