using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayerScript1 : MonoBehaviour
{
    CharacterMovement characterMovement;

    private void OnCollisionEnter()
    {
            characterMovement.playerSpeed -= 1;
    }
}