using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPowerUpHelper : MonoBehaviour
{
    #region Inspector Properties
    [SerializeField]  float shootForce = 200f; //   Defines the movement speed for the current actor
    [SerializeField]  int bulletAmount = 2; //   Defines the jump force for the current actor
    [SerializeField] GameObject bulletPrefab; //   Defines the jump force for the current actor
    [SerializeField] GameActorController Player; //   Defines the jump force for the current actor
    #endregion

    #region Private Properties
    protected Transform _transform; //Store a reference to the Transform
    List<int> _bulletPool;
    bool _isActive;
    public bool IsActive {  get => _isActive; set => _isActive = value; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       if( !_isActive)     
           return;
        if (Input.GetButtonDown("Fire2")){
            Function();
        }
        
    }

    void Function()
    {
        int  direccion;
      if (Player.IsFacingRight)
        {
            direccion = 1;
        }
        else
        {
            direccion = -1;
        }

       var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) ;
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2 (shootForce,0)*direccion);
        bullet.GetComponent<SpriteRenderer>().flipX = Player.IsFacingRight;
    }
}