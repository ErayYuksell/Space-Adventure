using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foots") // playerin ayaklari golda degdiginde ust objesindeki gold scriptinden goldClose calistirarak goldu kapatiyor
        {
            GetComponentInParent<Gold>().GoldClose();
            FindObjectOfType<Score>().GainGold();
        }
    }
}
