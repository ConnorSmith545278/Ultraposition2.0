using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private GameObject GameState;
    // Start is called before the first frame update
    void Start()
    {
        GameState = GameObject.FindGameObjectWithTag("GameStateTag");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameState.GetComponent<GameState>().batteries++;
        Destroy(gameObject);
    }
}
