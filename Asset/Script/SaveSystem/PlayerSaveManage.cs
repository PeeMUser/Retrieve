using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveManage : MonoBehaviour
{
    [SerializeField] SaveData saveData;
    TimerController time;
    public void SavePlayer()
    { 
            saveData.currentLevel = SceneManager.GetActiveScene().buildIndex;
            saveData.playerHP = 100;
            saveData.playerLocationX = gameObject.transform.position.x;
            saveData.playerLocationY = gameObject.transform.position.y;
            saveData.playerLocationZ = gameObject.transform.position.z;
            SaveManager.Save(saveData);
        }

    


    
       public void LoadGame()
        {
            Debug.Log("Loading game...");
            saveData = SaveManager.Load();

            gameObject.transform.position = new Vector3(saveData.playerLocationX, saveData.playerLocationY, saveData.playerLocationZ);
            SceneManager.LoadScene(saveData.currentLevel);
        }

  
    }

