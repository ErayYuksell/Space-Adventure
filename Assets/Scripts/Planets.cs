using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    List<GameObject> planets = new List<GameObject>();  
    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler"); //Resources ozel bir klasor icindeki Gezegenler spriteinin icindeki her bir elemani object dizisi olarak aliyorum
                                                            //Her donguye girdiginde bir sprite icin bir obje olusturarak o spritein ismini verdik ve listeye ekledik 
        for (int i = 0; i < 17; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer spriteRenderer = planet.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = (Sprite)sprites[i]; //cast islemi yaptik bak buna ?????
            planet.name = sprites[i].name;
            spriteRenderer.sortingLayerName = "Planets";
            planets.Add(planet);
        }
    }

   
    void Update()
    {
        
    }
}
