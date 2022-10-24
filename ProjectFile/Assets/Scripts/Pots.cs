using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Pots : MonoBehaviour
{
    public Animator anim;
    public InventoryObject inventory;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        inventory.Container.Clear();
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    public void PlayAnimation()
    {
        anim.SetTrigger("Active");
    }
}
