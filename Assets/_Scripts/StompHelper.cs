using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class StompHelper : MonoBehaviour
{

    #region Private Properties
    bool _isStomped = false;

    public bool IsStomped { get => _isStomped; }

    #endregion


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.transform.tag == "Player")
        {
            _isStomped = true;
        }
    }
}
