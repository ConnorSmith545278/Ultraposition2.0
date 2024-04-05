using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowBox : MonoBehaviour
{
    [SerializeField] private GameObject disturbance;
    [SerializeField] private GameObject breakableObject;
    [SerializeField] private ParticleSystem ps;
    private GameObject cam;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private GrowScript growScript;
    private CamShake CamShake;
    private bool sent;
    [SerializeField] private float shakerTime;

    // Start is called before the first frame update
    void Start()
    {
        growScript = disturbance.GetComponent<GrowScript>();
        cam = GameObject.Find("Main Camera");
        CamShake = cam.GetComponent<CamShake>();
        if(breakableObject != null)
        {
            sr = breakableObject.GetComponent<SpriteRenderer>();
            bc = breakableObject.GetComponent<BoxCollider2D>();
        }
        PlayerMovement.onDeath += Reset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!sent)
        {
            CamShake.shakeTime = shakerTime;
            growScript.growing = true;
            sent = true;
            if(breakableObject != null)
            {
                sr.enabled = false;
                bc.enabled = false;
                ps.Play();
            }
        }
    }

    private void Reset()
    {
        if(breakableObject != null)
        {
            sr.enabled = true;
            bc.enabled = true;
        }

        sent = false;
    }

    private void OnDestroy()
    {
        PlayerMovement.onDeath -= Reset;
    }
}
