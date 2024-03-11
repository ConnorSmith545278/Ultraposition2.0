using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorHandler : MonoBehaviour
{
    public GameObject anchor;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(anchor != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3 (anchor.transform.position.x, anchor.transform.position.y, -10f), ref velocity, smoothTime);
        }
    }
}
