using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsRaycastManager : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject overlayGroundFloor;

    [SerializeField]
    private GameObject overlayFirstFloor;

    [SerializeField]
    private GameObject overlaySecondFloor;

    [SerializeField]
    private GameObject overlayTopFloor;

    [SerializeField]
    private GameObject overlayAVGroundFloor;

    [SerializeField]
    private GameObject overlayAVFirstFloor;

    [SerializeField]
    private GameObject resetButton;

    [SerializeField]
    private GameObject crossHairVisual;

    [SerializeField]
    private GameObject[] targetObjects;

    [SerializeField]
    private Material highlightMaterial;

    Material originalMaterial;
    GameObject lastHighlightedObject;

    private GazePointer gazePointer;

	private void Awake()
	{
        gazePointer = GameObject.FindGameObjectWithTag("GazePointer").GetComponent<GazePointer>();
	}

    void HighlightMaterial(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            ClearHighlighted();
            originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
            lastHighlightedObject = gameObject;
        }
    }

    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            lastHighlightedObject = null;
        }
    }

	void FixedUpdate()
    {
        Ray ray = arCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        int groundFloor = LayerMask.GetMask("groundFloor");
        int firstFloor = LayerMask.GetMask("firstFloor");
        int secondFloor = LayerMask.GetMask("secondFloor");
        int topFloor = LayerMask.GetMask("topFloor");
        int avGroundFloor = LayerMask.GetMask("avGroundFloor");
        int avFirstFloor = LayerMask.GetMask("avFirstFloor");

        RaycastHit hitObject;
        // TODO: test different distances (third param)
        if (Physics.Raycast(ray, out hitObject, 1.5f, groundFloor))
        {
            HighlightMaterial(hitObject.collider.gameObject);

            //Start filling gazeImage
            gazePointer.startFillingGaze = true;

            if (gazePointer.fillingCompleted) {
                overlayGroundFloor.SetActive(true);
                resetButton.SetActive(false);
                crossHairVisual.SetActive(false);
                this.gameObject.SetActive(false);
            }

            // if (Input.touchCount > 0)
            // {
            //     Touch touch = Input.GetTouch(0);
            //     if (touch.phase == TouchPhase.Began)
            //     {
            //         Ray onObject = arCamera.ScreenPointToRay(touch.position);
            //         RaycastHit hit;
            //         //if (hitObject.collider.bounds.IntersectRay(onObject))
            //         if (Physics.Raycast(onObject, out hit) && hit.collider.name.Equals(hitObject.collider.name))
            //         {
            //             overlay.SetActive(true);
            //             this.gameObject.SetActive(false);
            //         }
            //     }
            // }
        } else if (Physics.Raycast(ray, out hitObject, 1.5f, firstFloor))
            {
            HighlightMaterial(hitObject.collider.gameObject);

            //Start filling gazeImage
            gazePointer.startFillingGaze = true;

            if (gazePointer.fillingCompleted)
            {
                overlayFirstFloor.SetActive(true);
                resetButton.SetActive(false);
                crossHairVisual.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else if (Physics.Raycast(ray, out hitObject, 1.5f, secondFloor))
        {
            HighlightMaterial(hitObject.collider.gameObject);

            //Start filling gazeImage
            gazePointer.startFillingGaze = true;

            if (gazePointer.fillingCompleted)
            {
                overlaySecondFloor.SetActive(true);
                resetButton.SetActive(false);
                crossHairVisual.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else if (Physics.Raycast(ray, out hitObject, 1.5f, topFloor))
        {
            HighlightMaterial(hitObject.collider.gameObject);

            //Start filling gazeImage
            gazePointer.startFillingGaze = true;

            if (gazePointer.fillingCompleted)
            {
                overlayTopFloor.SetActive(true);
                resetButton.SetActive(false);
                crossHairVisual.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else if (Physics.Raycast(ray, out hitObject, 1.5f, avGroundFloor))
        {
            HighlightMaterial(hitObject.collider.gameObject);

            //Start filling gazeImage
            gazePointer.startFillingGaze = true;

            if (gazePointer.fillingCompleted)
            {
                overlayAVGroundFloor.SetActive(true);
                resetButton.SetActive(false);
                crossHairVisual.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else if (Physics.Raycast(ray, out hitObject, 1.5f, avFirstFloor))
        {
            HighlightMaterial(hitObject.collider.gameObject);

            //Start filling gazeImage
            gazePointer.startFillingGaze = true;

            if (gazePointer.fillingCompleted)
            {
                overlayAVFirstFloor.SetActive(true);
                resetButton.SetActive(false);
                crossHairVisual.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            ClearHighlighted();
            gazePointer.startFillingGaze = false;
        }
  
    }

    public void DeactivateOverlay()
    {
        overlayGroundFloor.SetActive(false);
        overlayFirstFloor.SetActive(false);
        overlaySecondFloor.SetActive(false);
        overlayTopFloor.SetActive(false);
        overlayAVGroundFloor.SetActive(false);
        overlayAVFirstFloor.SetActive(false);
        resetButton.SetActive(true);
        crossHairVisual.SetActive(true);
        this.gameObject.SetActive(true);
    }
}
