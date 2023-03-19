using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float prefabSpeed;
    public bool changesHeight;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    public bool isPipe;
    public float spawnRate = 1f;

    public Transform leftEdgeTransform;

    private void OnEnable()
    {
        if(isPipe)
        {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        }

    }
    private void OnDisable()
    {
        
    }

    public void Spawn()
    {
        GameObject newObj = Instantiate(prefab, transform.position, Quaternion.identity);

        newObj.GetComponent<Movement>().SetSpawnedNext(false);
        Pipes pipe = newObj.GetComponent<Pipes>();
        newObj.transform.parent = this.transform;
        newObj.transform.position = transform.position;

        //newObj.GetComponent<Movement>().SetSpeed(prefabSpeed);
        if (changesHeight)
        {
            newObj.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        }
        if(pipe != null)
        {
            float rand = Random.Range(0.80f, 0.95f);
            pipe.SetTopPipeHeight(rand);
        }
    }
}
