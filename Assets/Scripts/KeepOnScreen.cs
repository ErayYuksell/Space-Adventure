using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnScreen : MonoBehaviour
{
    
    
    
    void Update()
    {
        if (transform.position.x < -ScreenCalculator.instance.Widht) // Playerin ekrandan cikamamasi icin yazdigimiz code
        {
            Vector2 temp = transform.position;
            temp.x = -ScreenCalculator.instance.Widht; // - olmasisin nedenis sistem orta noktayi 0 kabul ediyor o yuzden sol taraf -
            transform.position = temp;
        }
        if (transform.position.x > ScreenCalculator.instance.Widht)
        {
            Vector2 temp = transform.position;
            temp.x = ScreenCalculator.instance.Widht;
            transform.position = temp;
        }
    }
}
