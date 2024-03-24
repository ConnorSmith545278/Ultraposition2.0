using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] private float intensity;
    public float shakeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTime > 0)
        {
            gameObject.transform.position = new Vector3 ( gameObject.transform.position.x +Random.Range(-intensity,intensity), gameObject.transform.position.y + Random.Range(-intensity, intensity), gameObject.transform.position.z);
            shakeTime -= Time.deltaTime;
        }
    }
}
