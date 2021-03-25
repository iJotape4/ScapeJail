using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaController : MonoBehaviour
{
    #region Inspector Properties
    public bool trigger;
    public bool activation;
    public GameObject PalancaUIcon;
    #endregion

    #region Private Properties
    private Animator _animator;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        PalancaUIcon = GameObject.Find("PalancaUIcon"); PalancaUIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !activation)
        {
            PalancaUIcon.SetActive(true);

            if (Input.GetButtonDown("Submit") )
            {
                activation = true;
                _animator.SetBool("Activation", activation);
                PalancaUIcon.SetActive(false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PalancaUIcon.SetActive(false);
    }
}
