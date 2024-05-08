using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{

    [SerializeField] private Sprite space;
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D)) 
        {
            sr.sprite = space;
        }
        if(Input.GetKeyDown(KeyCode.Space) && sr.sprite == space)
        {
            Destroy(gameObject);
        }
    }
}
