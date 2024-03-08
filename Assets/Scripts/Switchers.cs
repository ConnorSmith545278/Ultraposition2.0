using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switchers : MonoBehaviour
{
    GameObject[] bluePlatforms;
    GameObject[] pinkPlatforms;
    private int switchCount = 1;
    private int currentSwitch;
    private List<BoxCollider2D> blueCols = new List<BoxCollider2D>();
    private List<BoxCollider2D> pinkCols = new List<BoxCollider2D>();

    // Start is called before the first frame update
    void Start()
    {
        bluePlatforms = GameObject.FindGameObjectsWithTag("Blue");
        pinkPlatforms = GameObject.FindGameObjectsWithTag("Pink");

        foreach (var bluePlatform in bluePlatforms)
        {
            blueCols.Add(bluePlatform.GetComponent<BoxCollider2D>());
        }


        foreach (var pinkPlatform in pinkPlatforms)
        {
            pinkCols.Add(pinkPlatform.GetComponent<BoxCollider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (currentSwitch)
            {
                case 0:

                    foreach(var col in blueCols)
                    {
                        col.enabled = false;
                    }
                    foreach(var  bluePlatform in bluePlatforms)
                    {
                        bluePlatform.GetComponent<SpriteRenderer>().color = new Color(0.28f, 0.32f,1,0.2f);
                    }
                    foreach(var col in pinkCols)
                    {
                        col.enabled = true;
                    }
                    foreach (var pinkPlatform in pinkPlatforms)
                    {
                        pinkPlatform.GetComponent<SpriteRenderer>().color = new Color(1f, 0.4f, 1, 1f);
                    }
                    break;

                case 1:
                    foreach (var col in blueCols)
                    {
                        col.enabled = true;
                    }
                    foreach (var bluePlatform in bluePlatforms)
                    {
                        bluePlatform.GetComponent<SpriteRenderer>().color = new Color(0.28f, 0.32f, 1, 1);
                    }
                    foreach (var col in pinkCols)
                    {
                        col.enabled = false;
                    }
                    foreach (var pinkPlatform in pinkPlatforms)
                    {
                        pinkPlatform.GetComponent<SpriteRenderer>().color = new Color(1f, 0.4f, 1, 0.2f);
                    }
                    break;

            }
            currentSwitch++;
            if(currentSwitch > switchCount)
            {
                currentSwitch = 0;
            }
        }
    }
}
