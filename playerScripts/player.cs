using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    playerMetodos pm = new();
    public static player instancia;
    [HideInInspector] public Rigidbody2D rbPlayer;
    [HideInInspector] public SpriteRenderer srPlayer;
    public BoxCollider2D bcPlayerDireita;
    public BoxCollider2D bcPlayerEsquerda;
    public static bool inimigoMeleeHit;
    Coroutine dashar;
    barras b;
    void Start()
    {
        instancia = this;
        rbPlayer = GetComponent<Rigidbody2D>();
        srPlayer = GetComponent<SpriteRenderer>();
        
    }
   
    void Update()
    {
        pm.movimentar(this, Btn.nomeBtn);
        pm.barraStamina();
        pm.barraVida(this);
    }
    public void movimento(){
        pm.movimentar2(this, BtnClick.nomeBtn);
    }
    //inicia o dash
    public void iniciarDash(playerAtributos pAtri){
        pAtri.stamina -= pAtri.dcStamina;
        dashar = StartCoroutine(Dashar(pAtri));
    }
    //para o dash
    public void pararDash(playerAtributos pAtri){
        StopCoroutine(dashar);
    }
    //faz o dash
    IEnumerator Dashar(playerAtributos pAtri){
        yield return new WaitForSeconds(0.3f);
        pAtri.isDashing = false;
        rbPlayer.velocity = new Vector2(0, rbPlayer.velocity.y);
        BtnClick.nomeBtn = "";
    }
  
    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.tag == "inimigoMelee"){
            inimigoMeleeHit = true;
        }
    }
}
