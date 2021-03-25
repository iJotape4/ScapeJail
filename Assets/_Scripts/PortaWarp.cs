using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

public class PortaWarp : MonoBehaviour
{
    #region Inspector properties
    public Object _escenaDestino;
    public GameObject UiCon;
    public bool triggered;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        UiCon = GameObject.Find("UiCon"); 
        UiCon.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Submit"))
            {
                SceneManager.LoadScene(_escenaDestino.name);

            }

            UiCon.SetActive(true);
            triggered = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UiCon.SetActive(false);
         
            triggered = false;
        }
    }
}
