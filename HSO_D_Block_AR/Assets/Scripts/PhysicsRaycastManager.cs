using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsRaycastManager : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject overlay;

    [SerializeField]
    private GameObject[] targetObjects;

    [SerializeField]
    private Material highlightMaterial;

    Material originalMaterial;
    GameObject lastHighlightedObject;

	private void Awake()
	{
        
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
        RaycastHit hitObject;
        // TODO: test different distances (third param)
        if (Physics.Raycast(ray, out hitObject, 0.5f))
        {
            HighlightMaterial(hitObject.collider.gameObject);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Ray onObject = arCamera.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    //if (hitObject.collider.bounds.IntersectRay(onObject))
                    if (Physics.Raycast(onObject, out hit) && hit.collider.name.Equals(hitObject.collider.name))
                    {
                        overlay.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }
        else
        {
            ClearHighlighted();
        }
  
    }

    public void DeactivateOverlay()
    {
        overlay.SetActive(false);
        this.gameObject.SetActive(true);
    }
}
