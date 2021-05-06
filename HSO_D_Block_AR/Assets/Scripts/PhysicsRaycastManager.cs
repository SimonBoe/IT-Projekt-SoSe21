using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsRaycastManager : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject targetObjects;

    private Color activeColor = Color.red;

    private Color inactiveColor = Color.green;

    private Vector2 touchPosition = default;

	private void Awake()
	{
        activeColor.a = 0.1f;
	}

	void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            // TODO: seperate touch phase from raycast. set material depending on raycast. ui panel setcative = true
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    targetObjects.GetComponent<Renderer>().material.color = activeColor;
                    Debug.Log("Hit");
                } else {
                    targetObjects.GetComponent<Renderer>().material.color = inactiveColor;
                }
            }
        }
    }
}
