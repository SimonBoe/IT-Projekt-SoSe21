using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	public void resetAR()
    {
        if (!GameObject.Find("VisualIndicator").activeInHierarchy)
            GameObject.Find("VisualIndicator").SetActive(true);
        Destroy(GameObject.Find("Model"));
    }
}
