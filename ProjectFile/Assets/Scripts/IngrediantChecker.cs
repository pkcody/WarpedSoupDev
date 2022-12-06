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
        int ItemCount = 0;
        int correctItem = 0;
        ScoreInst = GameObject.Find("ScoreSystem");
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            ItemCount += inventory.Container[i].amount;
        }
        TotalItemCount = ItemCount;
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
            correctItem += count[i];
        }
        CorrectItemCount = correctItem;
        CalculateScore();

    }

    public void CalculateScore()
    {
        ScoreCount = CorrectSets * 10 + CorrectItemCount * 3 - TotalItemCount;
        var currentScore = ScoreInst.GetComponent<ScoreSystem>().score + ScoreCount;
        ScoreText.text = currentScore.ToString("0");
    }
    void OnDestroy()
    {
        ScoreInst.GetComponent<ScoreSystem>().score += ScoreCount;
    }
}
