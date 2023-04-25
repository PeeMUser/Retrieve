using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLycan : MonoBehaviour
{
    public LoadingScreen load;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //werewolf
        if (other.CompareTag("Player"))
        {
            load.LoadScene(5);
        }
    }
}
