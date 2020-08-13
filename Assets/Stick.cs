using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    //adjust this to change speed
    public Vector3 speed = new Vector3();
    //adjust this to change how high it goes
    public float height = 0;


    float Timer;
    Vector3 OriginalPosition;

    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.localPosition;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed.magnitude);
        //set the object's Y to the new calculated Y
        //transform.localPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + newY, OriginalPosition.z) * height;

        transform.Translate(speed.x * Time.deltaTime, speed.y * Time.deltaTime, speed.z * Time.deltaTime, Space.Self);
        Timer += speed.magnitude;
        if (Mathf.Abs(Timer) > height) 
        {
            Timer = 0;
            speed *= -1;
        }
    }
}
