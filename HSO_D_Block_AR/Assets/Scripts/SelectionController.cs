using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    
    [SerializeField]
    private ObjectSelection[] placedObjects;

    private Color activeColor = Color.red;

    private Color inactiveColor = Color.white;

    [SerializeField]
    private Camera arCamera;

    private Vector2 touchPosition = default;

	void Start()
	{
        ChangeSelectedObject(placedObjects[0]);
        activeColor.a = 1f;
        inactiveColor.a = 0.35f;
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    ObjectSelection ObjectSelection = hitObject.transform.GetComponent<ObjectSelection>();
                    if (ObjectSelection != null)
                    {
                        Debug.Log("Hit");
                        ChangeSelectedObject(ObjectSelection);
                    }
                }
            }
        }
    }

    void ChangeSelectedObject(ObjectSelection selected)
    {
        foreach (ObjectSelection current in placedObjects)
        {
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if (selected != current)
            {
                current.IsSelected = false;
                meshRenderer.material.color = inactiveColor;
            }
            else
            {
                current.IsSelected = true;
                meshRenderer.material.color = activeColor;
            }
        }
    }
}
