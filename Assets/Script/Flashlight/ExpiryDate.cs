using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpiryDate : MonoBehaviour
{
    private DateTime expiryDate = new DateTime(2023, 12, 14, 11, 17, 50);
    // Start is called before the first frame update
    void Start()
    {
        if(DateTime.Now > expiryDate)
        {
            FlashLightToggle.instance.ToggleTorch();
        }
        
    }
}
