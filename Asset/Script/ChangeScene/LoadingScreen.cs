using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;


    private void Start()
    {
        loadingScreen.SetActive(false);
    }
    public void LoadScene(int id)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(id));
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
       

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            yield return null;
        }
    }
}
