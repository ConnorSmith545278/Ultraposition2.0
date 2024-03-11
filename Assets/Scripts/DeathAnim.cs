using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DeathAnim : MonoBehaviour
{
    private Volume volume;
    private bool playing;
    [SerializeField] private float animLength;
    private float apex;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.onDeath += Play;
        volume = gameObject.GetComponent<Volume>();
        apex = animLength / 2; 
    }

    // Update is called once per frame
    void Update()
    {
        if(playing == true)
        {
            currentTime += Time.deltaTime;
            volume.weight = -1/(apex*apex)*((currentTime-apex)*(currentTime-apex)) + 1;
        }
        if(currentTime>animLength)
        {
            playing = false;
            currentTime = 0;
        }
    }
    private void Play()
    {
        playing = true;
    }

}
