using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
