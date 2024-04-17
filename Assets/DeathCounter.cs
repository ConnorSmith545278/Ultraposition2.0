using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(tmp);
        gameState = GameObject.FindGameObjectWithTag("GameStateTag").GetComponent<GameState>();
        tmp.text = gameState.deaths.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
