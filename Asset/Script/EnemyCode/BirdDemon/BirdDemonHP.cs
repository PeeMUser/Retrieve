using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDemonHP : MonoBehaviour
{
    #region Public Variables
    public float maxHealth;
    public float currentHealth;
    #endregion

    #region Private Variables
    Animator anim;
   // Rigidbody2D enemy;
    BirdDemon enemylogic;
    
    
    #endregion

    private void Start()
    {
        currentHealth = maxHealth;
        
        anim = GetComponent<Animator>();
        enemylogic = GetComponent<BirdDemon>();

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
        //enemy.velocity = new Vector2(-10, transform.position.y);
        //
        //enemylogic.gameObject.
      
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //ScoreManager.instance.AddPointLycan();
        Debug.Log("Enemy Died");
        anim.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
        Destroy(enemylogic);
        
    }


    
}
