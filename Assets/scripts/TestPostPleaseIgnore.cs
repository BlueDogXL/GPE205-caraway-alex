using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPostPleaseIgnore : MonoBehaviour
{
    public float minFleeDistance = 1.0f;
    public float maxFleeDistance = 100.0f;

    public float minBravadoValue = 0;
    public float maxBravadoValue = 25;
    public float currentBravadoValue = 10;
    public float currentFleeDistance;
    // Start is called before the first frame update
    void Start()
    {
        float rangeOfFleeDistance = maxFleeDistance - minFleeDistance;
        float percentBravadoValue = currentBravadoValue / maxBravadoValue;
        float fleeAmountInFleeRange = (1 - percentBravadoValue) * maxFleeDistance;

        float fleeDistance = minFleeDistance + fleeAmountInFleeRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
