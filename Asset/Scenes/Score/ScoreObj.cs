using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObj : MonoBehaviour
{
    public ScoreManager score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            score.AddPointMagic();
            Destroy(this.gameObject);
        }
    }
}
