using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D pc2d;
    public bool movement;
    float randomSpeed;
    float min, max;
    void Start()
    {
        pc2d = GetComponent<PolygonCollider2D>();

        if (Options.EasyGetValue() == 1) // zorluk seviyesine gore platform hizini arttirdik
        {
            //Debug.Log("awdakwjd");
            randomSpeed = Random.Range(0.2f, 0.8f);
        }
        if (Options.MediumGetValue() == 1)
        {
            randomSpeed = Random.Range(0.5f, 1f);

        }
        if (Options.HardGetValue() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);

        }
        float objectWidht = pc2d.bounds.size.x / 2;
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
            GameObject player = GameObject.FindGameObjectWithTag("Player"); //ayaklari platforma degdiginde player platformun childi olur ve ayni sekilde sago sola hareket ederler
            player.transform.parent = transform;
            player.GetComponentInChildren<PlayerMovement>().ResetJump(); //ziplama limiti dolduktan sonra bir platforma temas ederse limiti 0 lar 
        }
    }
}
