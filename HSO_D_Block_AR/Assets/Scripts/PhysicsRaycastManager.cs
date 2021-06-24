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

    GameObject toShow = default;

	private void Awake()
	{
        gazePointer = GameObject.FindGameObjectWithTag("GazePointer").GetComponent<GazePointer>();
	}

    void HighlightMaterial(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            gazePointer.reset();
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

        RaycastHit hitObject;
        // TODO: test different distances (third param)
        if (Physics.Raycast(ray, out hitObject, 1.5f))
        {
            HighlightMaterial(hitObject.collider.gameObject);

            //Start filling gazeImage
            gazePointer.IsFilling = true;

            switch (hitObject.collider.gameObject.tag)
            {
                case "GroundFloor":
                    toShow = overlayGroundFloor;
                    break;
                case "FirstFloor":
                    toShow = overlayFirstFloor;
                    break;
                case "SecondFloor":
                    toShow = overlaySecondFloor;
                    break;
                case "TopFloor":
                    toShow = overlayTopFloor;
                    break;
                case "AVGroundFloor":
                    toShow = overlayAVGroundFloor;
                    break;
                case "AVFirstFloor":
                    toShow = overlayAVFirstFloor;
                    break;
                default:
                    break;
            }

            if (gazePointer.fillingCompleted) {
                // overlayGroundFloor.SetActive(true);
                toShow.SetActive(true);
                resetButton.SetActive(false);
                crossHairVisual.SetActive(false);
                this.gameObject.SetActive(false);
            }
        } 
        else
        {
            ClearHighlighted();
            gazePointer.reset();
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
        gazePointer.reset();
    }
}
