using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] Transform topPipeTransform;
    public void SetTopPipeHeight(float heightModificator)
    {
        Vector3 newPos = new Vector3(topPipeTransform.position.x, topPipeTransform.position.y * heightModificator, topPipeTransform.position.z);
        topPipeTransform.position = newPos;
    }
}
