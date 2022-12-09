using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour
{
    public int levelAmount = 3;
    public GameObject[] levels;

    void Start()
    {
        Instantiate(levels[Random.Range(0, 3)], new Vector3(0, 0, 0), transform.rotation);
    }
}
