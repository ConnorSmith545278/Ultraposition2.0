using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Switchers : MonoBehaviour
{
    GameObject[] bluePlatforms;
    BoxCollider2D[] blueCols;
    GameObject[] pinkPlatforms;
    private int switchCount;
    private int currentSwitch;
    // Start is called before the first frame update
    void Start()
    {
        bluePlatforms = GameObject.FindGameObjectsWithTag("Blue");
        

        foreach (var bluePlatform in bluePlatforms)
        {

        }
        pinkPlatforms = GameObject.FindGameObjectsWithTag("Pink");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (currentSwitch)
            {
                case 0:

                    foreach (var platform in bluePlatforms)
                    {
                        platform.GetComponent<BoxCollider2D>().enabled = false;
                    }
                    foreach(var platform in pinkPlatforms)
                    {
                        platform.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    break;

                case 1:
                    foreach (var platform in bluePlatforms)
                    {
                        platform.GetComponent<BoxCollider2D>().enabled = false;
                    }
                    foreach (var platform in pinkPlatforms)
                    {
                        platform.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    break;

            }
            currentSwitch++;
        }
    }
}
