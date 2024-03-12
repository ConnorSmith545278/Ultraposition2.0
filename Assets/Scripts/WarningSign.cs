using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WarningSign : MonoBehaviour
{
    private bool interactable;
    [SerializeField] private GameObject clickIcon;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject target2;
    [SerializeField] private GameObject warningIcon;
    [SerializeField] private float growthRate = 0.1f;
    private Vector2 targetPosition;
    private Vector2 targetPosition2;
    private bool screenVisible;
    private bool moveUp;
    private bool activated = true;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.transform.position;
        targetPosition2 = target2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && interactable)
        {
            screenVisible = true;
        }
        if(interactable && clickIcon.transform.localScale.x < 1f)
        {
            clickIcon.transform.localScale += new Vector3(growthRate, growthRate, growthRate);
        }
        if (!interactable && clickIcon.transform.localScale.x >0)
        {
            clickIcon.transform.localScale -= new Vector3(growthRate, growthRate, growthRate);
        }
        if (screenVisible)
        {
            warningIcon.transform.position = Vector3.Slerp (warningIcon.transform.position,new Vector3 (targetPosition.x, targetPosition.y, -1f), growthRate);
            if(Input.GetKeyDown (KeyCode.UpArrow) && interactable)
            {
                moveUp  = true;
                screenVisible = false;
                activated = true;
            }
        }
        if (moveUp)
        {
            warningIcon.transform.position = Vector3.Slerp(warningIcon.transform.position, new Vector3(targetPosition2.x, targetPosition2.y, -1f), growthRate/2);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !activated)
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
}
