using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBeam : MonoBehaviour
{
    private LineRenderer beam;
    private Vector3 origin;
    private Vector3 endPoint;

    // Start is called before the first frame update
    void Start()
    {
        beam = this.gameObject.AddComponent<LineRenderer>();
        beam.startWidth = 0.1f;
        beam.endWidth = 0.01f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        beamRay();
    }

    void beamRay()
    {
        origin = GameObject.FindGameObjectWithTag("MainCamera").transform.position + new Vector3(0f, -0.5f, -0.5f);
        endPoint = origin + GameObject.FindGameObjectWithTag("MainCamera").transform.forward * 40f;
        //endPoint = new Vector3(5, 5, 5);

        beam.SetPosition(0, origin);
        beam.SetPosition(1, endPoint);
        //beam.alignment = LineAlignment.TransformZ;
        beam.sortingLayerName = "Foreground";
        beam.enabled = true;
    }
}
