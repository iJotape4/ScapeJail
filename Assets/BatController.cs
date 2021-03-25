using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : GameActorController
{

    #region inspector Properties
    public float VSpeed = 2f;
    public float VMaxSpeed = 5f;
    public float HSpeed = 5f;
    public float HMaxSpeed = 5f;
    public float distance, rangedetection;
    public bool detected = false;
    public bool resting = true;
    public PlayerController2D Player;
    public Transform target;
    public Transform posinicial;
    public Animator animator;

    #endregion
    //  public Vector2 PosicionInicial = new Vector2(-63, -3);
    private Vector3 start, end;


    #region Private Properties
    protected Rigidbody2D _rigidbody2D;
    #endregion


    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //Player = GetComponent<PlayerController2D>();
        _rigidbody2D.gravityScale = 0f;


        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsResting();
        animator.SetBool("touching", detected);
        animator.SetBool("Resting", resting);
        detect();
        if (detected)
        {
            Chase();
        }

    }

    public void detect()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < rangedetection)
        {
            detected = true;
        }
        else { detected = false; comeback(); }
    }

    public void comeback()
    {
        float fixedSpeed = HSpeed * Time.deltaTime;


        transform.position = Vector3.MoveTowards(transform.position, posinicial.transform.position, fixedSpeed);
    }

    public void IsResting()
    {
        if (transform.position == posinicial.transform.position)
        {
            resting = true;
        }
        else
        {
            resting = false;
        }
    }

    private void FixedUpdate()
    {


    }

    void HMovement()
    {
         float limitedSpeed = Mathf.Clamp(_rigidbody2D.velocity.x, HMaxSpeed, HMaxSpeed);
        _rigidbody2D.velocity = new Vector2(limitedSpeed, _rigidbody2D.velocity.y);

        if (_rigidbody2D.velocity.x > -0.01f && _rigidbody2D.velocity.x < 0.01f)
        {
            HSpeed = -HSpeed;
            _rigidbody2D.velocity = new Vector2(HSpeed, _rigidbody2D.velocity.y);
        }

        //REFLEJAR El PERSONAJE
        if (HSpeed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (HSpeed < -0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }      _rigidbody2D.AddForce(Vector2.right * HSpeed);
 
    }


    public void Chase()
    {
        float fixedSpeed = HSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _rigidbody2D.AddForce(Vector2.right * -HSpeed);
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
            Destroy(this);
        }
    }



}


