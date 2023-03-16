using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameManager gameManager;
    Animator animator;
    [SerializeField] CinemachineVirtualCamera cam;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();

        animator.applyRootMotion = true;
        animator.SetBool("Die", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!gameManager.isGameOver)
        {
            if (other.CompareTag("Damage"))
            {
                gameManager.GameOver();
                cam.Follow = null;
                cam.LookAt = null;
                animator.applyRootMotion = false;
                animator.SetBool("Die", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!gameManager.isGameOver)
        {
            if (other.CompareTag("Check"))
            {
                gameManager.IncreaseScore();
            }
        }
    }
}
