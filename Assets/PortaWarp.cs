﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaWarp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.Instance.ActivateTutIcon("Uicon");
          

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.Instance.DesactivateTutIcon("UiCon");

        }
    }
}
