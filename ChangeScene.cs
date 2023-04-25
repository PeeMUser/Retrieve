using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public LoadingScreen load;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //loading Forest
        if (collision.CompareTag("Player"))
        {
            load.LoadScene(4);
        }

    }
}
