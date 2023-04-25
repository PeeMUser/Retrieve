using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBossMode : MonoBehaviour
{

    #region Public Variables
    public float speed = 5f;
    public float jumpSpeed = 3f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public float cooldown = 1.3f;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    public int pushPower = -10;
    public Rigidbody2D player;
    public float cooldownTime = 0.5f;
    public AudioSource sfx;
    public AudioClip hit, missed, Dashing;
    #endregion

    #region Private Variables
    private bool isCooldown;
    float timer = 0f;
    // private float direction;
    private Animator anim;
    // private SpriteRenderer render;
    // private float attackTimer = 0f;
    // private int combo = 0;
    // private bool attack1;
    //  private bool attack2;
    //  private int maxCombo = 3;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 2f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1.5f;
    private bool move = true;
    private float stoptime = 0.5f;
    //private bool canAttack = true;
    HPSystem hpSystem;
    [SerializeField] private TrailRenderer tr;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        // render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        hpSystem = GetComponent<HPSystem>();

    }
    public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                sfx.clip = missed;
                sfx.Play();
                //StartCoroutine("Attacking");
                Attack();
                timer = 0;
            }

        }

        if (timer < cooldownTime + 1)
            timer += Time.deltaTime;
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float direction = Input.GetAxis("Horizontal");


        if (isDashing)
        {
            return;
        }
        if (direction > 0f && move == true)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            //render.flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction < 0f && move == true)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            //render.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            anim.SetBool("Jump", true);

        }
        else
        {
            anim.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.K) && canDash)
        {

            StartCoroutine(Dash());

        }

        anim.SetFloat("Run", Mathf.Abs(direction));

        if (player.velocity.y < 0)
        {
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }



    }
    //void Attack()
    //{
    //  anim.SetTrigger("Attack");
    //}
    private IEnumerator Dash()
    {
        sfx.clip = Dashing;
        sfx.Play();
        canDash = false;
        isDashing = true;
        float originalGravity = player.gravityScale;
        player.gravityScale = 0f;
        player.velocity = new Vector2(player.velocity.x * dashingPower, 0f);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        player.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    private IEnumerator stopattack()
    {

        move = false;


        yield return new WaitForSeconds(stoptime);

        move = true;

    }
    void Attack()
    {

        {
            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {

                sfx.clip = hit;
                sfx.Play();

                Debug.Log("We hit" + enemy.name);
               // enemy.GetComponent<EnemyHP>().TakeDamage(attackDamage);
                enemy.GetComponent<BossHP>().TakeDamageBoss(attackDamage);
            }
            StartCoroutine("stopattack");

        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    public IEnumerator Attacking()
    {
        //canAttack = false;


        yield return new WaitForSeconds(0.01f);

        //canAttack = true;
    }
}

