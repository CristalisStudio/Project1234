using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera Cam;
    void Start()
    {
        Cam = Camera.main;
    }


    void Update()
    {
        Ray rayDoor = Cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    
    
    
    
    
    }
}
