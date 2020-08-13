using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color OriginalColor;

    void Start()
    {
        transform.GetComponent<MeshRenderer>().material.color = OriginalColor;
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Circle" || collision.gameObject.tag == "Item")
        {
            collision.transform.GetComponent<MeshRenderer>().material.color = OriginalColor;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Circle" || other.gameObject.tag == "Item")
        {
            other.transform.GetComponent<MeshRenderer>().material.color = OriginalColor;
        }
    }
}
