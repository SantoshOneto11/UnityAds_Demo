using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    LineRenderer policeLine;
    // Update is called once per frame
    private void Start()
    {
        policeLine = GetComponent<LineRenderer>();
    }
    void Update()
    {
        DrawPoliceLine();
    }
    void DrawPoliceLine()
    {
        float radius = Vector2.Distance(transform.position, PoliceSpawner.Instance.ReturnNearestPoint());
        
        policeLine.SetPosition(0, FindObjectOfType<Theif>().transform.position);
        //policeLine.SetPosition(1, pointOnRadius);
    }
}
