/*
Author: JP
Date: Tuesday 02/March/2021  @ 08:15:14
Description: Base class for that defines the behavior of the game actors
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : GameActorController
{
    [SerializeField] public palancaController Palanca;
    // Store the movement or the current timestep
    #region Private  Properties
    [SerializeField] PlayerPowerUpHelper PowerUpHelper;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    new void Update()
    {

        //Implement Character movement
        base.Update();
        //1. obtener el input en  X
        _vx = Input.GetAxisRaw("Horizontal");

        if (movement)
        { 

        if (Input.GetButtonDown("Jump") && _isGrounded && movement ) {

            _isJumping = true;
        } else if (Input.GetButtonUp("Jump") && movement)
        {
            _isJumping = false;
            _vy = 0;
        }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
         
            GameManager.Instance.Updatelives(-1);
            EnemyKnockBack(collision.transform.position.x);
           if( GameManager.Instance.IsGameOver)
            {
                gameObject.SetActive(false);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lost" && Palanca.activation )
        {
              UIManager.Instance.ShowGameOver();
            Time.timeScale = 0;
        }
    }

    public void ActivatePowerUp()
    {
        PowerUpHelper.IsActive = true;
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        _isKnockBacking = true;
        _isJumping = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);

        _rigidbody2D.AddForce(Vector2.left * side * jumpForce/100 , ForceMode2D.Impulse);
        _rigidbody2D.AddForce(Vector2.up * jumpForce / 50, ForceMode2D.Impulse);
        movement = false;
       
        //CAMBIO DE COLORS
        _sprite.color = Color.red; //Color Rojo
        Color color = new Color(255 / 255f, 106 / 255f, 0 / 255f); //Color creado (anaranjado rojizo)
        _sprite.color = color;
        Invoke("EnableMovement", 1f);


    }

    void EnableMovement()
    {
        movement = true;
        _sprite.color = Color.white;
        _isKnockBacking = false;

    }


}
