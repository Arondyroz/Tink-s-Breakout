using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    [SerializeField] private float distancePos;
    public GameObject teleportEffect;
    public GameManager gmScript;
    public GameObject destroyAnim;
    public Animator camAnim;
    public bool isDead;
    public bool startGame;
    public float startMoveTime;
    public SpriteRenderer arrowSprite;
    public bool endGame = false;
    public BoxCollider2D colPlayer;
    public Vector2 currentPos;
    [Header("Audio Source")]
    public AudioSource teleportSFX;

    private bool changeColor = false;
    private Animator playerAnim;
    private Vector3 mousePosition;
    private SpriteRenderer spriteRend;
    private Rigidbody2D playerRb;
    private float moveTime;
    //private AudioSource destroySelf;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       currentPos = transform.position;
       colPlayer = GetComponent<BoxCollider2D>();
       playerAnim = GetComponent<Animator>();
       moveTime = startMoveTime;
       spriteRend = GetComponent<SpriteRenderer>();
       playerRb = GetComponent<Rigidbody2D>();
       //destroySelf = destroyAnim.GetComponent<AudioSource>();
       isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        ColorMoveClick();
    }

    void LookAtArrow()
    {

    }
    void ColorMoveClick()
    {
        if (changeColor == false)
        {
            arrowSprite.color = Color.blue;
            MoveClick(distancePos, true);
        }
        else
        {
            arrowSprite.color = Color.red;
            MoveClick(-distancePos, false);
        }
    }

    void MoveClick(float direction, bool colors)
    {
        
        if (isDead == false && startGame == true && endGame == false)
        {            
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            if (Input.GetMouseButtonDown(0))
            {
                camAnim.SetTrigger("Shake");
                TeleportEffect();
                transform.position = Vector2.MoveTowards(transform.position, mousePosition, direction);
                //playerRb.velocity = mousePosition * direction;
                changeColor = colors;
                playerAnim.SetBool("ChangeColor", colors);
            }
        }
    }

    void TeleportEffect()
    {
        GameObject telEffect = Instantiate(teleportEffect, transform.position, transform.rotation);
        Destroy(telEffect, 0.2f);
        teleportSFX.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Lose();
        }
    }

    public void Lose()
    {
        isDead = true;
        Instantiate(destroyAnim, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
        gmScript.LosePanel();
    }

}
