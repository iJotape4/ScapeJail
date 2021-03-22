using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController2D : GameActorController
{
    #region Inspector Properties
    [SerializeField] StompHelper stompCheck;
    public float maxSpeed = 5f;

    #endregion
    #region Private Properties
    protected Rigidbody2D _rigidbody2D; //Store a reference to the rigidbody2D
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        stompCheck = GetComponentInChildren<StompHelper>();
        _vx = -10f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        // TODO: Update with actual A.I Behavior
        

        if (stompCheck.IsStomped)
        {
            gameObject.SetActive(false);
        }


       // Debug.Log(_rigidbody2D.velocity.x);

        _rigidbody2D.AddForce(Vector2.right * _vx);
        float limitedSpeed = Mathf.Clamp(_rigidbody2D.velocity.x, -maxSpeed, maxSpeed);
        _rigidbody2D.velocity = new Vector2(limitedSpeed, _rigidbody2D.velocity.y);

        if (_rigidbody2D.velocity.x > -0.01f && _rigidbody2D.velocity.x < 0.01f)
        {
            _vx = -_vx;
            _rigidbody2D.velocity = new Vector2(_vx, _rigidbody2D.velocity.y);
        }

    }

    new void FixedUpdate()
    {
        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _vx = -_vx;
    }
}
