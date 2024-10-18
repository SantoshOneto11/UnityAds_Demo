using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    public Dictionary<string, Boss> keyValuePairs;
    bool isClicked;

    private void Start()
    {
        keyValuePairs = new Dictionary<string, Boss>();
        AddValues();
    }

    public void AddValues()
    {
        var boss1 = "First Boss";
        var boss2 = "Second Boss";
        var enemy1 = new Boss { Name = boss1 };
        var enemy2 = new Boss { Name = boss2 };

        keyValuePairs.Add(boss1, enemy1);
        keyValuePairs.Add(boss2, enemy2);       
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && !isClicked)
        {
            GetAllBoss();
            isClicked = true;
        }
    }
    public void GetAllBoss()
    {
        foreach (var pair in keyValuePairs)
        {
            string bossIndex = pair.Key;
            var boses = pair.Value;

            Debug.Log(bossIndex + " ----> " + boses);
        }
    }

    public class Boss
    {
        public string Name;
    }
}
