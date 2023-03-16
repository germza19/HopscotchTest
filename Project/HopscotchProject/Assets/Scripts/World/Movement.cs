using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed { get; private set; }
    private float worldLeftEdge;
    public Transform endPos;
    private bool spawnedNextPrefab;
    private Spawner spawner;

    private void Start()
    {
        spawner = GetComponentInParent<Spawner>();
        worldLeftEdge = spawner.leftEdgeTransform.position.x;
        spawnedNextPrefab = false;
        SetSpeed(spawner.prefabSpeed);
    }

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > worldLeftEdge)
        {
            Destroy(gameObject);
        }
        if(endPos != null)
        {
            if (endPos.position.x > spawner.transform.position.x && spawnedNextPrefab == false)
            {
                spawner.Spawn();
                spawnedNextPrefab = true;
            }
        }

    }
    public void SetSpeed(float speedValue)
    {
        speed = speedValue;
    }
    
}