using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float pull = 20;
    [SerializeField] private float pullMax;
    [SerializeField] private float pullRange;
    private float circleSize;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        circleSize = pullRange / 1.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<BoxCollider2D>().enabled == true)
        {
            Vector3 pullVector = new Vector3(0, pull, 0);
            if(Vector2.Distance(player.transform.position, gameObject.transform.position)<pullRange)
            {
                pullVector = (player.transform.position - gameObject.transform.position) * pull;
                player.GetComponent<Rigidbody2D>().AddForce(pullVector);
            }
        }
    }
}
