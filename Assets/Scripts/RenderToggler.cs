using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderToggler : MonoBehaviour
{
    public void ToggleRenderer()
    {
        gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
    }
}
