using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] SaveData svdata;
    private void Start()
    {
        svdata.currentLevel = SceneManager.GetActiveScene().buildIndex;
        

        SaveManager.Save(svdata);
    }
    public void RetryButton()
    {
        svdata = SaveManager.Load();

      
        SceneManager.LoadScene(svdata.currentLevel);
    }
}
