using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class HPSystem : MonoBehaviour
{
    #region Public Variables
    public float maxHealth;
    public float currentHealth;
    public float healing;
    public int damage;
    public GameObject effect;
    public PlayerSaveManage save;
    public GameObject retrypanel;
    #endregion

    #region Private Variables
    Animator anim;
    Movement life;
    HPSystem methods;
    private EnemyBehaviour enemydamage;
    private bool inCollider = false;
    Movement player;
    MovementBossMode lifebossmode;
    private Renderer renderer;
    Color C;


 
    #endregion


    private void Start()
    {
        currentHealth = maxHealth;
        
        anim = GetComponent<Animator>();
        enemydamage = GetComponent<EnemyBehaviour>();
        life = GetComponent<Movement>();
        renderer = GetComponent<Renderer>();
        C = renderer.material.color;
        lifebossmode = GetComponent<MovementBossMode>();
        save.SavePlayer();
        




    }


    private void Update()
    {
        
        if (currentHealth <= 0)
        {
            Die();
            Destroy(player);
        }
        

    }

    void ApplyHealing()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = currentHealth + healing;
        }
    }

   

    public void Die()
    {

        
        anim.SetTrigger("Hurt");
        Debug.Log("Hero is Death!");
        anim.SetBool("Death", true);
        GetComponent<Collider2D>().isTrigger = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         this.enabled = false;
        Destroy(life);
        Destroy(player);
        Destroy(lifebossmode);
        StartCoroutine(ResetTime());
        
        //StartCoroutine("ResetTime");
  
        
    }
    public void Awaken()
    {
        if (currentHealth == 0)
        {
            currentHealth = 100;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inCollider == false)
        {
            if (collision.CompareTag("Lycan"))
            {
                currentHealth = currentHealth - 25;
                inCollider = true;
                StartCoroutine("GetInvulnerable");

                if (currentHealth > 0)
                {
                    anim.SetTrigger("Hurt");

                }
                Instantiate(effect, transform.position, Quaternion.identity);

            }

            
            else if (currentHealth == 0)
            {
                Die();
            }
           
             
               
        }
        if (inCollider == false)
        {
            if (collision.CompareTag("Bird"))
            {
                currentHealth = currentHealth - 10;
                inCollider = true;
                StartCoroutine("GetInvulnerable");

                if (currentHealth > 0)
                {
                    anim.SetTrigger("Hurt");

                }
                Instantiate(effect, transform.position, Quaternion.identity);
            }


            else if (currentHealth == 0)
            {
                Die();
            }
        }
        if (inCollider == false)
        {
            if (collision.CompareTag("Trap"))
            {
                currentHealth = currentHealth - currentHealth;
                inCollider = true;
                StartCoroutine("GetInvulnerable");

                if (currentHealth > 0)
                {
                    anim.SetTrigger("Hurt");

                }
                Instantiate(effect, transform.position, Quaternion.identity);
            }


            else if (currentHealth == 0)
            {
                Die();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(inCollider == true)
        {
            if (collision.CompareTag("Lycan"))
            {
                
                inCollider = false;

            }
        }
    }
    public IEnumerator GetInvulnerable()
    {
        
        Physics2D.IgnoreLayerCollision(8, 9, true);
        C.a = 0.5f;
        renderer.material.color = C;
        yield return new WaitForSeconds(1.5f);
        Physics2D.IgnoreLayerCollision(8,9, false);
        C.a = 1f;
        renderer.material.color = C;
        
    }
    public IEnumerator ResetTime()
    {

        yield return new WaitForSeconds(3f);
        retrypanel.SetActive(true);

    }
    public object SaveState()
    {
        return new SaveData()
        {
            currentHealth = this.currentHealth,
            maxHealth = this.maxHealth
        };
    }
    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        currentHealth = saveData.currentHealth;
        maxHealth = saveData.maxHealth;
     }

    [System.Serializable]
    private struct SaveData
    {
        public float maxHealth;
        public float currentHealth;
    }
  
   
}

