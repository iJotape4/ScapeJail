using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{

    #region Inspector properties
    [Range(0, 2)]
    [SerializeField] protected float velocity = 2f; //   Defines the jump force for the current actor
    #endregion

    #region Private Properties

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDirection(Vector2 vector)
    {
       Vector2 direccion = vector;

    }
}
