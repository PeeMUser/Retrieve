using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDemon : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    #endregion

    #region Private Variables
    private GameObject player;
    private Animator anim;
    EnemyHP Hp;
    BirdDemon bird;
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        Hp = GetComponent<EnemyHP>();
        bird = GetComponent<BirdDemon>();
    }
    private void Update()
    {
        if (Hp.currentHealth <= 0)
        {
            Destroy(bird);
        }

        if (player == null)
            return;
        if (chase == true)
            Chase();

        else
            Flip();

    }
    private void Chase()
    {
        anim.SetBool("Flying", true);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
    private void ReturnStartingPoint()
    {
        anim.SetBool("Flying", true);
        anim.SetBool("Attack", false);
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}

     
 

 


