using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
        transform.position = new Vector3(Mathf.Clamp(player.instancia.transform.position.x, 0, 9999999999), Mathf.Clamp(player.instancia.transform.position.y, 0, 300), transform.position.z);
    }
}
