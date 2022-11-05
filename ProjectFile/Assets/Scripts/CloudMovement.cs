using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += new Vector3(.05f, 0, 0);
    }
}
