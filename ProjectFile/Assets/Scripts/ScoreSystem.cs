using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    public int score = 0;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
