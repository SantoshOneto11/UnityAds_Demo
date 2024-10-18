using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunClock : MonoBehaviour
{
    [SerializeField] SandClock clock;
    private void Start()
    {
        clock.onRoundStart += OnRoundStart;
        clock.onRoundEnd += OnRoundEnd;
        clock.onAllRoundsComplete += OnAllRoundsComplete;

        clock.Begin();
    }

    void OnRoundStart(int round)
    {
        Debug.Log("Round Start " + round);
    }

    void OnRoundEnd(int round)
    {
        Debug.Log("Round End " + round);
    }

    void OnAllRoundsComplete()
    {
        Debug.Log("--------> Time is Over <--------");
    }

    private void OnDestroy()
    {
        clock.onRoundStart -= OnRoundStart;
        clock.onRoundEnd -= OnRoundEnd;
        clock.onAllRoundsComplete -= OnAllRoundsComplete;            
    }
}
