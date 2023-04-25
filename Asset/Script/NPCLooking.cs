using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLooking : MonoBehaviour
{
    public SpriteRenderer renderSp;


    private void Update()
    {
        renderSp = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            renderSp.flipX = true;
        }
    }
}
  