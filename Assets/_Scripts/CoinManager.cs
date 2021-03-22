using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EdgeCollider2D))]
public class CoinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameManager.Instance.AddCoin();
            this.gameObject.SetActive(false);
        }
    }


}
