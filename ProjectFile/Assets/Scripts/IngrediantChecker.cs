using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngrediantChecker : MonoBehaviour
{
    public RecipeScriptableObject recipe;
    public InventoryObject inventory;
    public int[] count = new int[4];
    public int TotalItemCount;
    public int CorrectItemCount;
    public int CorrectSets;
    public int ScoreCount;
    public GameObject ScoreInst;
    [SerializeField] TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        TotalItemCount = 0;
        CorrectItemCount = 0;
        CorrectSets = 0;
        for (int i = 0; i < 4; i++)
        {
            count[i] = 0;
        }
    }
    public void CheckTrigger()
    {
        ScoreInst = GameObject.Find("ScoreSystem");
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            TotalItemCount += inventory.Container[i].amount;
        }

        for (int i = 0; i < 4; i++)
        {
            
            for (int j = 0; j < inventory.Container.Count; j++)
            {
                if(inventory.Container[j].item == recipe.Container[i])
                {
                    count[i] = inventory.Container[j].amount;
                }
            }
            CorrectSets = count[0];
            if (CorrectSets > count[i])
            {
                CorrectSets = count[i];
            }
            CorrectItemCount += count[i];
            Debug.Log(CorrectItemCount);
        }

        CalculateScore();

    }

    public void CalculateScore()
    {
        ScoreCount = CorrectSets * 5 + CorrectItemCount * 2 - TotalItemCount;
        ScoreInst.GetComponent<ScoreSystem>().score += ScoreCount;
        ScoreText.text = ScoreInst.GetComponent<ScoreSystem>().score.ToString("0");
    }

}
