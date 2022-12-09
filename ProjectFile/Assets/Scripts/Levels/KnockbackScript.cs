using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
    public float thrust = 100f;
    public Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Knife"))
        {
            rb.AddForce(-transform.right * thrust, ForceMode.Impulse);
        }
    }
}
