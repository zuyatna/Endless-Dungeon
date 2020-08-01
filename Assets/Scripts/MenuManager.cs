﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject loadingPanel;
    
    public Slider loadingSlider;
    
    public void Loading(int sceneIndex)
    {
        StartCoroutine(LoadingAsynchronously(sceneIndex));
    }
    
    public void QuitApplication()
    {
        Application.Quit();
    }
    
    IEnumerator LoadingAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingPanel.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingSlider.value = progress;

            yield return null;
        }
    }
}
