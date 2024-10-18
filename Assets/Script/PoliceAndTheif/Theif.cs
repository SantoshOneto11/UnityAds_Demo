using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Theif : MonoBehaviour
{
    private float moveSpeed = 10f;          // Move speed at which theif will run.
    LineRenderer line;
    List<Vector3> pos = new List<Vector3>();
    [SerializeField] float magnetRange = 2f;
    [SerializeField] private bool isMagnetic = true;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnetic)
            MagnetController();

        // Using unity's inbuilt move system to move the object in the scene. 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
    }

    void MagnetController()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject coin in coins)
        {
            float distance = Vector2.Distance(transform.position, coin.transform.position);
            if (distance <= magnetRange)
            {
                coin.transform.DOLocalMove(transform.position, 1f, false).OnComplete(() => coin.GetComponent<SpriteRenderer>().DOFade(0, 0.5f));

            }
        }


    }
}