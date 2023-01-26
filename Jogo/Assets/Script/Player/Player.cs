using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player inst;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject feetPosition; 
    [SerializeField] private float radiusSphere = 3f;
    [SerializeField] private float jumpForce =3f;
    
    private float dir; 
    private Rigidbody2D rb;
    [SerializeField] private float speed = 3f;

 
    private bool isGround = true;
    private bool facingRight = true;

    private HeartBar heartBar;
    private int health = 100;

    [Header("KncockBack")]
    [SerializeField] private float kbForce;
    [SerializeField] private float kbCounter;
    [SerializeField] private float kbdelay;
    [SerializeField] private bool knockFromRigh ;

    public Rigidbody2D PlayerRb { get => rb; set => rb = value; }
    public float KbCounter { get => kbCounter; set => kbCounter = value; }
    public float Kbdelay { get => kbdelay; set => kbdelay = value; }
    public bool KnockFromRigh { get => knockFromRigh; set => knockFromRigh = value; }
    public bool IsGround { get => isGround; set => isGround = value; }
    public GameObject FeetPosition { get => feetPosition; set => feetPosition = value; }

    private void Awake() {
        if(inst == null){
            inst = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        heartBar = FindObjectOfType<HeartBar>();
        heartBar.SetMaxHealth(100);
        
    }

    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal");        
        IsGround = Physics2D.OverlapCircle(FeetPosition.transform.position, radiusSphere, groundLayer);
        Jump();

    }

    private void FixedUpdate()
    {
        if(KbCounter <= 0){
            MovPlayer(dir);
        }else{
            rb.velocity = new Vector2(KnockFromRigh ? -kbForce : kbForce, rb.velocity.y);

            KbCounter -= Time.deltaTime;
        }
    }

    private void MovPlayer(float dir){
        rb.velocity = new Vector2(speed * dir, rb.velocity.y);

        if(dir > 0 && !facingRight || dir < 0 && facingRight){
            Flip();
        }

    }

    private void Flip(){
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    private void Jump(){
        if(IsGround && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpForce;
            PlayerAnim.inst.PlayerState = playerState.Jump;
        }        
    }

    public void TakingDamage(int damage){
        health -= damage;
        heartBar.SetHealth(health);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(FeetPosition.transform.position, radiusSphere);        
    }
}
