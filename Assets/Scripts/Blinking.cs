using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    private float frequency = 1;
    private float currentCount;
    private bool active;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCount = currentCount + Time.deltaTime;
        if (currentCount > frequency)
        {
            currentCount = 0;
            active = !active;
            sr.enabled = active;
        }
    }
}
