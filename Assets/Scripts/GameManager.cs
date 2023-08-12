using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
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
    }

    private GameManager()
    {

    }

    public static GameManager GetInstance()
    {
        return instance;
    }
    #endregion

    [SerializeField]
    private Image loadingScreen;


    public void LoadGame()
    {
        StartCoroutine(LoadGameAsync());
    }

    private IEnumerator LoadGameAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingScreen.color = new Color(loadingScreen.color.r, loadingScreen.color.g, loadingScreen.color.b, progress);

            yield return null;
        }
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadMenuAsync());
        Time.timeScale = 1;
    }

    private IEnumerator LoadMenuAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Menu Scene");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingScreen.color = new Color(loadingScreen.color.r, loadingScreen.color.g, loadingScreen.color.b, progress);

            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
