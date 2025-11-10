using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneTrigger : MonoBehaviour
{
    public int levelIndex;
    public float timeEx = 2f;
    public GameObject loadingScreen;
    public Slider sliderCharge;
    //contacto con el trigger 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ChangeLevel(levelIndex));
        }        
    }
    //cambio de nivel
    IEnumerator ChangeLevel(int levelIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            sliderCharge.value = progress;
            yield return null;
        }
        //yield return new WaitForSeconds(timeEx);
        //SceneManager.LoadScene(levelIndex);
    }
}
