using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class palancaController : MonoBehaviour
{
    #region Inspector Properties
  
    public bool activation;
    public GameObject PalancaUIcon;
    #endregion

    #region Private Properties
    private Animator _animator;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        activation = false; 
        _animator = GetComponent<Animator>();
        PalancaUIcon = GameObject.Find("PalancaUIcon"); PalancaUIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !activation)
        {
            PalancaUIcon.SetActive(true);

            if (Input.GetButtonDown("Submit"))
            {
                activation = true;
                _animator.SetBool("Activation", true);
                PalancaUIcon.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PalancaUIcon.SetActive(false);
    }

}
