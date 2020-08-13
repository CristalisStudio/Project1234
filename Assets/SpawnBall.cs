using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{

    public GameObject Ball;

    void Start()
    {
        
    }


    void Update()
    {
     
    }
   
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Instantiate(Ball);
        }
    }
}
