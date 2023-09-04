using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    public bool movement;
    float randomSpeed;
    float min, max;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1f);
        float objectWidht = boxCollider2D.bounds.size.x / 2;
        if (transform.position.x > 0) // bu kisimda platformlarin ekrandan cikmamasi icin islem yapiliyor 
        {
            min = objectWidht;
            max = ScreenCalculator.instance.Widht - objectWidht;
        }
        else
        {
            min = -ScreenCalculator.instance.Widht + objectWidht;
            max = -objectWidht;
        }
    }

    
    void Update()
    {
        if (movement)
        {
            float pingPong = Mathf.PingPong(Time.time * randomSpeed, max - min) + min; //    sag sola dogru git gel haraketi saglayan bir matf fonksiyonu
            Vector2 vec = new Vector2(pingPong, transform.position.y);
            transform.position = vec;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foots")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }
}
