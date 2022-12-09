using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3 : MonoBehaviour
{

    public GameObject flourBag;
    public Transform spawn;
    public float speed = 2500;

    private void OnTriggerEnter()
    {
        GameObject flourBagInstance = Instantiate(flourBag, spawn.position, spawn.rotation);
        Rigidbody rb = flourBagInstance.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, speed);
        Destroy(flourBagInstance, 3);

    }

}
