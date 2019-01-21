using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
#region
    //movement
    [SerializeField] private float speed;
    [SerializeField] private float force;
    [SerializeField] private float velocityX;
    [SerializeField] private float rotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool flipped = false;
    [SerializeField] private bool onGround;
    [SerializeField] private bool upSideDown = false;    

    //Components
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator anim;
 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform flopCheck;

    [SerializeField] private LayerMask groundLayer;

    //Misc
    [SerializeField] private bool isDead = false;
    [SerializeField] private GameObject audioSource;
    [SerializeField] private bool audioPlayable = true;
    [SerializeField] private float timer;
#endregion
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        sr.GetComponent<SpriteRenderer>();
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);
        upSideDown = Physics2D.OverlapCircle(flopCheck.position, 0.15f, groundLayer);
        Debug.Log(upSideDown);
        if (upSideDown == true)
            BrokenBones();

        if (Input.GetKeyDown("space") && onGround == true)
            rb.AddForce(new Vector3(rb.velocity.x, force), 0);

        

        if (Input.GetKeyDown("q") && onGround == true)
        {
            Debug.Log("woof");
            anim.SetBool("bark", true);
            
            anim.SetBool("bark", false);                            
        }
    }

    void FixedUpdate()
    {

        if (!upSideDown && !isDead)
        {
            velocityX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            rb.velocity = new Vector3(velocityX, rb.velocity.y);
        }
        if (velocityX > 0)
        {
            sr.flipX = true;
            flipped = true;
        }
        else if (velocityX < 0)
        {
            sr.flipX = false;
            flipped = false;
        }

        rotation = Input.GetAxisRaw("Vertical") * rotationSpeed * Time.deltaTime;

        if (!flipped)
            rb.AddTorque(-rotation);

        else
            rb.AddTorque(rotation);
    }

    public void BrokenBones()
    {
        isDead = true;
        speed = 0;
        force = 0;

        AudioController audioS = audioSource.GetComponent<AudioController>();

        if (audioPlayable)
        {
            audioS.PlayOof();
            audioPlayable = false;
        }


        Debug.Log("KYS!...oh wait, nvm");
    }
    public void ModifySpeed(float amount)
    {
        speed *= amount;

    }
    public void ModifyForce(float amount)
    {
        force *= amount;
    }
    public void ModifyOnGround()
    {
        onGround = !onGround;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            BrokenBones();
        }
    }

}
