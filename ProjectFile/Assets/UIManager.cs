using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] UIElement;
    
    public void UpdateUI()
    {
        foreach (GameObject a in UIElement)
        {
            a.GetComponent<DisplayInventory>().UpdateDisplay();
        }
    }
}
