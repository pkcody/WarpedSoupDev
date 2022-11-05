using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimerScene2 : MonoBehaviour
{
    public GameObject cam;
    public GameObject ScoreTrigger;
    float currentTime = 0f;
    public float startingTime = 30f;
    bool triggerOn = true;
    Color red = Color.red;

    [SerializeField] TextMeshProUGUI countdownText;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 10 && triggerOn)
        {
            ScoreTrigger.GetComponent<IngrediantChecker>().CheckTrigger();
            triggerOn = false;
            Debug.Log("go");
        }

        if (currentTime <= 5)
        {
            countdownText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            cam.transform.position = new Vector3(-100, 0, 0);
            ChangeScene.instance.ChangeToScene("Credits");
        }
    }
}

