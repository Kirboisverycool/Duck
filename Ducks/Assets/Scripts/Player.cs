
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 15f;
    public int extraJumps = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;
    [SerializeField] int health = 3;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileCoolDown = 0.1f;

    int jumpCount = 0;
    bool isGrounded;
    float mx;
    float jumpCoolDown;

    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation) as GameObject;
            if(transform.localScale.x == 1)
            {
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
            }
            else if(transform.localScale.x == -1)
            {
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
            }
            
            yield return new WaitForSeconds(projectileCoolDown);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer otherDamageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (otherDamageDealer == null) { return; }
        ProcessHit(otherDamageDealer);
    }

    private void ProcessHit(DamageDealer otherDamageDealer)
    {
        health -= otherDamageDealer.GetDamage();
        otherDamageDealer.Hit();
        if (health <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadLoseScene();
            Destroy(gameObject);
            
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Fire();

        mx = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        CheckGrounded();

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }

        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
