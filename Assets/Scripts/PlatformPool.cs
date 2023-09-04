using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject dPlatformPrefab;
    public GameObject playerPrefab;
    List<GameObject> platforms = new List<GameObject>();
    Vector2 platformPosition;
    Vector2 playerPosition;
    public float platformDistance;
    void Start()
    {
        PlatformCreate();
    }


    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            placePlatform();
        }
        //platforms listindeki son eleman bize ekranin en ust noktasini verir bu yuzden en ust noktayi gectiysek platformlarin yer degistirmesi icin gereken code
    }
    void PlatformCreate() //ilk platform playerin oldugu yerde yani 0 0 noktasinda olusmasini saglayan code 
    {
        platformPosition = new Vector2(0, 0);
        playerPosition = new Vector2(0, 0.5f);
        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);  //player objesinin bir platform uzerinden oldugundan emin olmak icin ilkini kendim ve haraketsiz olusturdum
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        PlatformNextPosition();
        firstPlatform.GetComponent<Platform>().movement = true;
        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().movement = true;
            if (i % 2 == 0) // her 2 nin kati olan platformlarda gold cikicak
            {
                platform.GetComponent<Gold>().GoldOpen();
            }
            PlatformNextPosition();
        }
        GameObject deadlyPlatform = Instantiate(dPlatformPrefab, platformPosition, Quaternion.identity); // her platform dongusunde 1 tane olumcul platform olusturmasini sagliyorum 
        deadlyPlatform.GetComponent<DPlatform>().movement = true;
        platforms.Add(deadlyPlatform);
        PlatformNextPosition();
    }
    void PlatformNextPosition() // ilk platformdan sonra sureklu positionsu degistirerek farkli yerlerde platform olusmasini saglar 
    {
        platformPosition.y += platformDistance;
        float random = Random.Range(0f, 1f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.instance.Widht / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Widht / 2;

        }
    }
    void placePlatform() 
                         //ilk 5 platformu listenin sonraki 5 li elemani haline getiriyor 
                         // camera en ust noktaya ulastiginda calisir ve ilk 5 platformla son 5 li nin yerini degistirir  
                         // surekli olarak objelerin olsuturulup yok edilmesi yerine ayni objeleri bir kere olsuturduktan sonra kullanma object pool deniyor
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPosition;
            if (platforms[i + 5].gameObject.tag == "Platform") //5 den sonra yukari tasinan platformlarda rastele altin uretme
            {
                platforms[i + 5].GetComponent<Gold>().GoldClose();
                float randomGold = Random.Range(0f, 1f);
                if (randomGold > 0.5f)
                {
                    platforms[i + 5].GetComponent<Gold>().GoldOpen();
                }
            }
            PlatformNextPosition();
        }
    }
}
