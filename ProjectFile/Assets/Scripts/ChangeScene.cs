using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void StartGameScene()
    {
        if (PlayerSpawning.instance.players[0] != null)
        {
            SceneManager.LoadScene("CollectGameSide");
        }
    }

    public void ChangeToScene(string scene)
    {
        SceneManager.LoadScene(scene);
        
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerSpawning.instance.ChangePlayerInput();
        PlayerSpawning.instance.StartingPositions();
    }
}
