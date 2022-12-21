using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaInimigo23 : MonoBehaviour
{
    private Rigidbody2D rbBala;
    public static bool balaColisao;
    void Start()
    {
        rbBala = GetComponent<Rigidbody2D>();
        if(inimigo.esquerda){
            rbBala.velocity = new Vector2(-10, 0);
        }else{
            rbBala.velocity = new Vector2(10, 0);
        }
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "Player"){
            balaColisao = true;
            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
