using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BackGroundMovementControl : MonoBehaviour
{
    float distance = 10.24f;  //sprite uzunlugu aslinda bu
    float backGroundPosition;
    void Start()
    {
        backGroundPosition = transform.position.y;
    }

    
    void Update()
    {
        if (backGroundPosition + distance < Camera.main.transform.position.y) 
            //ilk gorsel cameranin gorus acisindan ciktigi an diger gorselin ustune cikar bu sekilde sonsuz bir uzay yapmis olduk
        {
            PlaceBackGround();
        }
    }
    void PlaceBackGround()
    {
        backGroundPosition += (distance * 2); //2 ile carpmamizin nedeni alttaki sprite y konumu 0 gozukuyor 10.24 cikarirsak ustteki sprite ustune gelir bir ustu icin 20.48 lazim
        Vector2 position = new Vector2(0, backGroundPosition);
        transform.position = position;
    }
}
