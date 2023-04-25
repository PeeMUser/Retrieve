using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int health = 1000;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    public GameObject effect;
    public GameObject deatheffect;
    public AudioSource audiosource;
    public AudioClip beforerage, enraged;
    Werewolf_Run bodywolf;
    Animator anim;
    ScoreManager score;
   // private Color originalColor;

    private void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        audiosource.clip = beforerage;
        audiosource.Play();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        
    }
    public void TakeDamageBoss(int damage)
    {
        if (isInvulnerable)
            return;
        health -= damage;
        Instantiate(effect, transform.position, Quaternion.identity);
        if (health <= 200)
        {
            
          
            GetComponent<Animator>().SetBool("Raged", true);
        }
        if (health == 200)
        {
            audiosource.clip = enraged;
            audiosource.Play();
        }
            if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        Debug.Log("Boss Died");
        GetComponent<Collider2D>().enabled = false;
        anim.SetBool("Death", true);
        this.enabled = false;
        Destroy(this);
        Destroy(bodywolf);
        score.AddPointBoss();
    }

}
