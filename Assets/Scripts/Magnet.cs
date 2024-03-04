using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float pull = 20;
    [SerializeField] private float pullMax;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pullVector = new Vector3 (0,pull,0);

        pullVector = (player.transform.position - gameObject.transform.position)*pull;

        player.GetComponent<Rigidbody2D>().AddForce(pullVector);
    }
}
