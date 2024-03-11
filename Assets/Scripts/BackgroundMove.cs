using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float resetDistance;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        resetDistance = moveSpeed;

        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
        if(transform.position.y>startPosition.y+resetDistance)
        {
            transform.position = startPosition;
        }
    }
}
