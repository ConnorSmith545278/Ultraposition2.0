using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int batteries;
    public int deaths;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerMovement.onDeath += CountUp;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CountUp()
    {
        deaths++;
    }
}
