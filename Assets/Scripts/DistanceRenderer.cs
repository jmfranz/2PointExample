using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceRenderer : MonoBehaviour
{
    private bool isDistanceEnabled;
    public float distance;

    void Start()
    {
       isDistanceEnabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (isDistanceEnabled)
        {

            if (distance > 8f)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    public void ToggleDistanceRenderer()
    {
        isDistanceEnabled = !isDistanceEnabled;
    }

}
