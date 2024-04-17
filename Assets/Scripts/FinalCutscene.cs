using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutscene : MonoBehaviour
{
    private bool interactable;
    [SerializeField] private GameObject clickIcon;
    [SerializeField] private GameObject target;
    [SerializeField] private ParticleSystem Particles1;
    [SerializeField] private ParticleSystem Particles2;
    [SerializeField] private float growthRate = 0.00005f;
    [SerializeField] private float iconGrowthRate = 0.1f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject spike1;
    [SerializeField] private GameObject spike2;
    [SerializeField] private GameObject spike3;
    [SerializeField] private GameObject spike4;
    [SerializeField] private int sceneloader;

    private GameObject player;
    private Vector2 targetPosition;
    private bool activated;
    private float animLength = 3;
    private float particleTimer;
    private bool hasEnded;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.transform.position;
        player = GameObject.FindWithTag("Player");
        particleTimer = animLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            activated = true;
            interactable = false;
            player.GetComponent<PlayerMovement>().delay = animLength + 0.2f;
            mainCamera.GetComponent<CamShake>().shakeTime = animLength;
            Particles1.Play();
            Particles2.Play();
        }
        if (interactable && clickIcon.transform.localScale.x < 1f)
        {
            clickIcon.transform.localScale += new Vector3(iconGrowthRate, iconGrowthRate, iconGrowthRate);
        }
        if (!interactable && clickIcon.transform.localScale.x > 0)
        {
            clickIcon.transform.localScale -= new Vector3(iconGrowthRate, iconGrowthRate, iconGrowthRate);
        }
        if (activated)
        {
            if (!hasEnded)
            {
                player.transform.position = Vector3.Slerp(player.transform.position, new Vector3(targetPosition.x, targetPosition.y, -1f), growthRate/2);
                particleTimer -= Time.deltaTime;
                if (spike1.transform.localScale.x > 0)
                {
                    spike1.transform.localScale -= new Vector3(growthRate, growthRate, growthRate);
                }
                if (spike2.transform.localScale.x > 0)
                {
                    spike2.transform.localScale -= new Vector3(growthRate, growthRate, growthRate);
                }
                if (spike3.transform.localScale.x > 0)
                {
                    spike3.transform.localScale -= new Vector3(growthRate, growthRate, growthRate);
                }
                if (spike4.transform.localScale.x > 0)
                {
                    spike4.transform.localScale -= new Vector3(growthRate, growthRate, growthRate);
                }
                if (particleTimer < 0f)
                {
                    End();
                    Destroy(spike1);
                    Destroy(spike2);
                    Destroy(spike3);
                    Destroy(spike4);
                }
            }
            if (particleTimer < -1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !activated)
        {
            interactable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !activated)
        {
            interactable = false;
        }
    }
    private void End()
    {
        Particles1.Stop();
        Particles2.Stop();
        hasEnded = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneloader);
    }
}
