using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayRecipe : MonoBehaviour
{
    public int X_START;
    public int Y_START;
    public int Y_SPACE;
    public int X_SPACE;
    public int NUM_OF_COLUMN;
    public RecipeScriptableObject Recipe1;
    private List<GameObject> stored;
    // Start is called before the first frame update
    public void display()
    {
        for (int i = 0; i < 4; i++)
        {
            var obj = Instantiate(Recipe1.Container[i].prefab, Vector3.zero, Quaternion.identity, transform);
            Debug.Log("a");
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponent<RectTransform>().localScale = new Vector3(2f, 1.5f, 2f);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = Recipe1.Container[i].itemName;
            obj.GetComponentInChildren<TextMeshProUGUI>().fontSize = 3f;
            obj.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            //stored.Add(obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE * (i % NUM_OF_COLUMN)), Y_START + (-Y_SPACE * (i / NUM_OF_COLUMN)), 0f);
    }
}
