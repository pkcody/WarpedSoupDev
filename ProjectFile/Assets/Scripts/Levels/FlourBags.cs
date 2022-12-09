using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourBags : MonoBehaviour
{

    public GameObject flourBag;
    public Transform spawn;
    public float speed = 2500;
    public CharacterMovement characterMovement;

    private void OnTriggerEnter()
    {
        GameObject flourBagInstance = Instantiate(flourBag, spawn.position, spawn.rotation);
        Rigidbody rb = flourBagInstance.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -speed);
        Destroy(flourBagInstance, 3);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
