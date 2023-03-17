using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        transform.Rotate(0f,0f, -1f * (speed * Time.deltaTime));
    }
}
