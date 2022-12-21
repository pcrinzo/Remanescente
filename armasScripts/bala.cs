using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
 
    private Rigidbody2D rbBala;

   

    void Start()
    {
        rbBala = GetComponent<Rigidbody2D>();
        if(arma.esquerda){
            rbBala.velocity = new Vector2(-10, 0);
        }else{
            rbBala.velocity = new Vector2(10, 0);
        }
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "inimigoRanged" || colisao.gameObject.tag == "inimigoMelee"){
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
