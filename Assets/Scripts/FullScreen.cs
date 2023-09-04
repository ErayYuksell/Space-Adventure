using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Bir gorselin ayarlarini degistiriceksem spriteRenderer componentini kullanirim 
        Vector2 tempScale = transform.localScale;// scale kismini tutuyor
        float spriteWidth = spriteRenderer.size.x; // x ekseninde kac birim uzunlukta onu aldik
        //Camera ozelliklerinde olan size 5 diyelim cameranin etrafina bakis acisidir yani yukari asagi saga sola her bir tarafa uzakligi 5 oluyor 
        float screenHeight = Camera.main.orthographicSize * 2.0f; //yukseklik 5 asagi 5 yukari bu yuzden 2 ile carpmam lazim 
        float screenWidth = screenHeight / Screen.height * Screen.width; //screen classi oyunun calistigi cihaza gore ekran degerlerini alabilecegimiz yer 
        tempScale.x = screenWidth / spriteWidth;
        transform.localScale = tempScale;
        //ustteki code un tamami ile farkli cihazlara gore backGround un x scale degeri otamatik degisir

    }

    
    void Update()
    {
        
    }
}
