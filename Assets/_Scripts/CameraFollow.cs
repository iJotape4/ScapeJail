using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Name
    [SerializeField] PlayerController2D objectToFollow; //Objetos a seguir
    #endregion

    #region Inspector Properties
    [Range(0, 4)]
    [SerializeField] protected float YRange = 2f; //   Defines the jump force for the current actor
   
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (objectToFollow == null)
            Debug.LogError("Missing component !");
    }

    // Update is called once per frame
    void Update()
    {
         if (objectToFollow != null )
             this.transform.position = new Vector3(
                 objectToFollow.transform.position.x,   
                 objectToFollow.transform.position.y + YRange,
                 this.transform.position.z);
    }
}
