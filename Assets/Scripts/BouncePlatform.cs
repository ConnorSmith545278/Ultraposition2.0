using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField] private float shotStrength;
    private Vector3 shotOriginal;
    private Vector3 shot;
    private float zr;

    // Start is called before the first frame update
    void Start()
    {
        shotOriginal = new Vector3 (0,shotStrength,0);
        zr = transform.rotation.eulerAngles.z - 90;
        shot = new Vector3 (0,shotStrength);
        shot = Quaternion.AngleAxis(zr, Vector3.forward) *shotOriginal;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = shot;
        Debug.Log("hit");
    }
}
