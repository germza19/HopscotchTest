using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputController : MonoBehaviour
{
    //PlayerManager playerManager;
    private Vector3 direction;

    public float gravity;
    public float strength;

    [SerializeField] float liftInputCooldownTime;
    private float liftInputTime;
    private bool canLiftInput;

    public void Awake()
    {
        //playerManager = GetComponent<PlayerManager>();
        canLiftInput = true;
    }

    private void Update()
    {
        SetLiftInputTimer();
        PlayerInput();
    }

    public void PlayerInput()
    {
        
        if ((Input.GetKeyDown(KeyCode.Space) ||
            (Input.GetMouseButtonDown(0)) && !CheckIfMouseIsOverUI() )
            && canLiftInput)
        {
            direction = Vector3.up * strength;
            SetLiftInput(false);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                SetLiftInput(false);
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void SetLiftInput(bool value)
    {
        canLiftInput = value;
    }

    public void SetLiftInputTimer()
    {
        if (!canLiftInput)
        {
            liftInputTime += Time.deltaTime;
            if (liftInputTime >= liftInputCooldownTime)
            {
                SetLiftInput(true);
                liftInputTime = 0.0f;
            }
        }
    }

    private bool CheckIfMouseIsOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log("Its over UI elements");
            return true;
        }
        else
        {
            //Debug.Log("Its NOT over UI elements");
            return false;
        }
    }
}
