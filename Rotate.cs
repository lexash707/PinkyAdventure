using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    void Update()
    {
        transform.Rotate(0,0,360 * 2f * Time.deltaTime);
    }
}
