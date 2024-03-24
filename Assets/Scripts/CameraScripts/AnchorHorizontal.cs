using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorHorizontal : MonoBehaviour
{
    [SerializeField] private float maxPosition;
    private float minPosition;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        minPosition = gameObject.transform.position.x;
        PlayerMovement.onDeath += Reset;
    }


    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x <= maxPosition && player.transform.position.x >= minPosition)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y);
        }
    }

    private void Reset()
    {
        transform.position = new Vector3 (minPosition, transform.position.y, transform.position.z);
    }
}
