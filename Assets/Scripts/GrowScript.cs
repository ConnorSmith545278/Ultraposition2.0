using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowScript : MonoBehaviour
{
    [SerializeField] private float growthRate;
    [SerializeField] private float maxGrowth;
    public bool growing;

    private Vector3 startSize;
    
    // Start is called before the first frame update
    void Start()
    {
        startSize = transform.localScale;
        PlayerMovement.onDeath += Reset;
    }

    // Update is called once per frame
    void Update()
    {

        if (growing && maxGrowth >= transform.localScale.x)
        {
            transform.localScale += new Vector3(growthRate * Time.deltaTime, growthRate * Time.deltaTime);
        }
    }

    private void Reset()
    {
        growing = false;
        transform.localScale = startSize;
    }
}
