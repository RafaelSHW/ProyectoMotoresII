using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScreens : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider sliderCharge;
    public void LoadLvl(int sceneIndex) 
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            sliderCharge.value = progress;
            yield return null;
        }
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
