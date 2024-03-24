using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    private GameObject cameraHandler;
    [SerializeField] private GameObject thisAnchor;
    [SerializeField] private float transitionDelay;
    [SerializeField] public float camSize;
    // Start is called before the first frame update
    void Start()
    {
        cameraHandler = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (cameraHandler.GetComponent<AnchorHandler>().anchor != thisAnchor)
            {
                cameraHandler.GetComponent<AnchorHandler>().anchor = thisAnchor;
                collision.gameObject.GetComponent<PlayerMovement>().checkpoint = collision.gameObject.transform.position;
                collision.gameObject.GetComponent<PlayerMovement>().delay = transitionDelay;
            }
        }
        cameraHandler.GetComponent <AnchorHandler>().cameraSize = camSize;
    }
}
