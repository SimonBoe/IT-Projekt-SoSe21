using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GazePointer gazePointer;

	private void Start()
	{
        gazePointer = GameObject.FindGameObjectWithTag("GazePointer").GetComponent<GazePointer>();
	}

	// private static GameObject visualIndicator;
	public event Action OnClicked;

    // Method attached to Reset Button in Canvas
    public void ResetAR()
    {
        OnClicked?.Invoke();
        gazePointer.deactivateCrosshair();
    }
}
