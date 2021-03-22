/*
Author: JP
Date: Tuesday 02/March/2021  @ 08:15:14
Description: Base class for that defines the behavior of the game actors
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class GameActorController : MonoBehaviour
{

    #region inspector Properties
    [SerializeField] protected float movementSpeed = 250f; //   Defines the movement speed for the current actor
    [SerializeField] protected float jumpForce = 2f; //   Defines the jump force for the current actor
    [Range(0, 2)]
    [SerializeField] protected float groundCheckDistance =0f;
    [Tooltip("Define la capa que el suelo del juego")]
    [SerializeField] protected LayerMask whatIsGround;
    #endregion

    #region Private Properties
    protected Rigidbody2D _rigidbody2D; //Store a reference to the rigidbody2D
    protected  Transform _transform; //Store a reference to the Transform
    protected Animator _animator; //Store a reference to the Animator
    protected AudioSource _audioSource; //Store a reference to the AudioSource
    protected CapsuleCollider2D _collider; //Store a reference to the collider
    protected SpriteRenderer _sprite ;

    protected bool _isGrounded = true;
    protected bool _isRunning = false;
    protected bool isAttacking = false;
    protected bool _isJumping = false;
    protected bool _isKnockBacking = false;
    protected bool _isFalling = true;
    protected bool _isFacingRight = true;
    public bool IsFacingRight { get => _isFacingRight;  }
    public bool IsGrounded { get => _isGrounded; }
    public bool movement =true;

    protected float _vx;
    protected float _vy;

    #endregion

    

    void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<CapsuleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
       // _sprites = GetComponent<PlayerPowerUpHelper>().IsActive = false;

        if (_transform == null)
            Debug.LogError("Missing component !");
        if (_rigidbody2D == null)
            Debug.LogError("Missing component !");
        if (_animator == null)
            Debug.LogError("Missing component !");
        if (_audioSource == null)
            Debug.LogError("Missing component !");
        if (_collider == null)
            Debug.LogError("Missing component !");


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    
    // Update is called once per frame
    protected void Update()
    {
        // Comprobar si está tocando el suelo
        DoGroundCheck(_transform.position, new Vector2(_transform.position.x, _transform.position.y -groundCheckDistance));
        _vy = _rigidbody2D.velocity.y;
       
        DoAnimation();

                
    }

    protected void FixedUpdate(){

        if (!movement) { return; }
        DoMove();
         if (_isJumping && _isGrounded)
            DoJump();


    }

    //Makes the character jump
    protected void DoJump()
    {
        _vy = 0;
        _rigidbody2D.AddForce(new  Vector2(0, jumpForce));
        _isJumping = false;
    }

      void DoMove()
    {
        _rigidbody2D.velocity = new Vector2(_vx*movementSpeed* Time.deltaTime, _vy);
        if (_vx !=0 )
            _isRunning = true;
        else
            _isRunning = false; 
       
    }

    void DoAnimation ()
    {
        Flip ();
        _animator.SetBool("IsRunning", _isRunning);
        if (!_isGrounded)
        _animator.SetTrigger("IsJumping");

     
        _animator.SetBool("IsKnockBacking", _isKnockBacking);

        _animator.SetBool("IsGrounded", _isGrounded);
    }

    void Flip()
    {
        if (_vx  <0  && _isFacingRight)
        {
            _sprite.flipX =true;
            _isFacingRight = false;
        }
        else if (_vx > 0 && !_isFacingRight)
        {
            _sprite.flipX =false;
            _isFacingRight = true;
        }
        
    }

    void DoGroundCheck(Vector3 start, Vector2 end)
    {
        _isGrounded = Physics2D.Linecast(start, end, whatIsGround);
        Debug.DrawLine(start, end,Color.magenta);
    }

}
