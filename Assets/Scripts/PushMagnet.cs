using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMagnet : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float pull = 20;
    [SerializeField] private float pullMax;
    [SerializeField] private float pullRange;
    private float circleSize;
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject particles;
    private ParticleSystem system;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        circleSize = pullRange / 1.8f;
        circle.transform.localScale = new Vector3(circleSize, circleSize, 1);
        system = particles.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BoxCollider2D>().enabled == true)
        {
            system.startSpeed = 5;
            system.Play(true);
            Vector3 pullVector = new Vector3(0, pull, 0);
            if (Vector2.Distance(player.transform.position, gameObject.transform.position) < pullRange)
            {
                pullVector = (player.transform.position - gameObject.transform.position) * pull * Time.deltaTime * 200;
                player.GetComponent<Rigidbody2D>().AddForce(pullVector);
            }
        }
        else
        {
            system.startSpeed = 1;
        }
    }
}
