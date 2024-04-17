
using UnityEngine;

public class MoreScript : MonoBehaviour
{

    private bool interactable;
    [SerializeField] private GameObject clickIcon;
    [SerializeField] private GameObject target;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ParticleSystem Particles1;
    [SerializeField] private ParticleSystem Particles2;
    [SerializeField] private ParticleSystem Particles3;
    [SerializeField] private float growthRate = 0.1f;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject popup;

    private GameObject gameState;
    private GameState GS;
    private GameObject player;
    private Vector2 targetPosition;
    private bool activated = false;
    private float animLength = 3;
    private float particleTimer;
    private bool hasEnded;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.transform.position;
        player = GameObject.FindWithTag("Player");
        particleTimer = animLength;
        gameState = GameObject.FindGameObjectWithTag("GameStateTag");
        GS = gameState.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && popup.transform.localScale.x < 1f && GS.batteries < 6)
        {
            popup.transform.localScale += new Vector3(growthRate, growthRate, growthRate);
        }
        if (!interactable && popup.transform.localScale.x > 0)
        {
            popup.transform.localScale -= new Vector3(growthRate, growthRate, growthRate);
        }
        if (interactable && clickIcon.transform.localScale.x < 1f && GS.batteries==6)
        {
            clickIcon.transform.localScale += new Vector3(growthRate, growthRate, growthRate);
        }
        if (!interactable && clickIcon.transform.localScale.x > 0)
        {
            clickIcon.transform.localScale -= new Vector3(growthRate, growthRate, growthRate);
        }
            if (Input.GetKeyDown(KeyCode.E) && interactable && GS.batteries == 6)
            {
                activated = true;
                interactable = false;
                player.GetComponent<PlayerMovement>().delay = animLength + 0.2f;
                mainCamera.GetComponent<CamShake>().shakeTime = animLength;
                Particles1.Play();
            Particles2.Play();
            Particles3.Play();
            }
        if (activated)
        {
            if (!hasEnded)
            {
                player.transform.position = Vector3.Slerp(player.transform.position, new Vector3(targetPosition.x, targetPosition.y, -1f), growthRate);
                particleTimer -= Time.deltaTime;
                if (particleTimer < 0f)
                {
                    End();
                }
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
        Particles3.Stop();
        hasEnded = true;
        Destroy(wall);

    }
}
