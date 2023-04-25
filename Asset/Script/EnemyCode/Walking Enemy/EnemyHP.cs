using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    #region Public Variables
    public float maxHealth;
    public float currentHealth;
    public GameObject effect;
    public ScoreManager score;
    //public GameObject effectdie;
    #endregion

    #region Private Variables
    Animator anim;
   // Rigidbody2D enemy;
    EnemyBehaviour enemylogic;
    Rigidbody2D rb;
    EnemyBehaviour2 enemylogicIdle;
    BearBehaviour bear;
    
    
    
    #endregion

    private void Start()
    {
        currentHealth = maxHealth;
        
        anim = GetComponent<Animator>();
        enemylogic = GetComponent<EnemyBehaviour>();
        rb = this.GetComponent<Rigidbody2D>();
        enemylogicIdle = GetComponent<EnemyBehaviour2>();
        bear = GetComponent<BearBehaviour>();
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Damaging(int canDamage)
    {
        
    }
    public void TakeDamage(int damage)
    {
       
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        Instantiate(effect, transform.position, Quaternion.identity);
        

        //enemy.velocity = new Vector2(-10, transform.position.y);
        //
        //enemylogic.gameObject.

        if (currentHealth <= 0)
        {
            Die();
           
        }
    }
    public void Die()
    {
        
        //Instantiate(effectdie, transform.position, Quaternion.identity);
        //ScoreManager.instance.AddPointLycan();
        Debug.Log("Enemy Died");
        anim.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(this);
        Destroy(enemylogic);
        Destroy(enemylogicIdle);
        Destroy(bear);
        score.AddPointMonster();
    }



}
