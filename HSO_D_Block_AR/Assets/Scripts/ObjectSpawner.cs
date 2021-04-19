using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    // in editor select the prefab which is instatiated by tapping the screen
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;

    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        // check touches
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {


            //instantiate object, if instance of object already exists, destroy object before instantiate new object

            if (GameObject.FindGameObjectWithTag("objectToSpawn"))
            {
                Destroy(GameObject.FindGameObjectWithTag("objectToSpawn"));
                GameObject spawnedObject = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
                GameObject.FindGameObjectWithTag("visualIndicator").SetActive(false);
            }
            else {
                GameObject spawnedObject = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
                GameObject.FindGameObjectWithTag("visualIndicator").SetActive(false);
            }
        }
    }
}
