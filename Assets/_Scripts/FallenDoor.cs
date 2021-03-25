using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenDoor : MonoBehaviour
{
    #region Inspector Properties
    public bool activation;
    [SerializeField] public palancaController Palanca;
    #endregion

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
      

    }

    // Update is called once per frame
    void Update()
    {

        activation = Palanca.activation;
        if (activation )
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;

        }
    }
}

