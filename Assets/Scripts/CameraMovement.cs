using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //kameranin zaman icinde hizlanan sekilde yukari haraket etmesi lazim
    public float speed;
    public float addSpeed;
    public float maxSpeed;
    bool movement = true; // default olarak false
    void Start()
    {

        if (Options.EasyGetValue() == 1) // zorluk seviyesine gore camera hizi ayarladik 
        {
            speed = 0.3f;
            addSpeed = 0.03f;
            maxSpeed = 1.5f;
        }
        if (Options.MediumGetValue() == 1)
        {
            speed = 0.5f;
            addSpeed = 0.05f;
            maxSpeed = 2f;
        }
        if (Options.HardGetValue() == 1)
        {
            speed = 0.8f;
            addSpeed = 0.08f;
            maxSpeed = 2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            CameraMove();
        }

    }
    void CameraMove()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += addSpeed * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
   public void GameOver()
    {
        movement = false;
    }
}
