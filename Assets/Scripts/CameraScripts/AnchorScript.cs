using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorScript : MonoBehaviour
{
    [SerializeField] private float maxPosition;
    private float minPosition;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        minPosition = gameObject.transform.position.y;
        PlayerMovement.onDeath += Reset;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y <= maxPosition && player.transform.position.y >= minPosition)
        {
            gameObject.transform.position = new Vector3 (gameObject.transform.position.x, player.transform.position.y);
        }
    }

    private void Reset()
    {
        transform.position = new Vector3(transform.position.x, minPosition, transform.position.z);
    }

    private void OnDestroy()
    {
        PlayerMovement.onDeath -= Reset;
    }
}
