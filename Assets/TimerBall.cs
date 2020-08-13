using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimerBall : MonoBehaviour
{
    public int Timer = 2400;
    public TextMesh TextCounter;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.Find("Counter").gameObject.activeSelf)
        {
            Timer--;
            TextCounter.transform.GetComponent<TextMesh>().text = "" + Timer / 60;
            if (Timer <= 0) Destroy(transform.gameObject);
        }
    }
}
