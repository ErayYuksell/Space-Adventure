using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject gold = default; //gold sprite inin uzerine bos obje acarak collider ve scripti buraya ekledik cunku animasyon ve collider birlikte duzgun calismiyor 
    public void GoldOpen()
    {
        gold.SetActive(true);
    }
    public void GoldClose()
    {
        gold.SetActive(false);

    }
}
