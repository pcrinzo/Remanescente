using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    
    inimigoMetodos im = new();
    inimigoAtributos ia = new();
    public List<inimigoAtributos> inimigos = new List<inimigoAtributos>();
    public static inimigo instancia;
    [HideInInspector] public Rigidbody2D rbInimigo;
    [HideInInspector] public SpriteRenderer srInimigo;
    [HideInInspector] public BoxCollider2D bcInimigo;
    [HideInInspector] public Animator animInimigo;
    public BoxCollider2D bcInimigoPadrao;
    public BoxCollider2D bcInimigoDireita;
    public BoxCollider2D bcInimigoEsquerda;
    public GameObject goBala;
    public int ativarTrigger;
    public static bool esquerda;
    Coroutine atirar;
    string[] listaTags = {"inimigoMelee", "inimigoRanged"};


    //[HideInInspector] public Animator animInimigo;
    void Start()
    {
        instancia = this;
        rbInimigo = GetComponent<Rigidbody2D>();
        srInimigo = GetComponent<SpriteRenderer>();
        bcInimigo = GetComponent<BoxCollider2D>();
        animInimigo = GetComponent<Animator>();
        //animInimigo = GetComponent<Animator>();
        
        ia.vida = 100;
        ia.velocidade = 1;
        ia.dano = 15;
        ia.posX = transform.position.x;
        ia.posY = transform.position.y;
        ia.ativarTrigger = ativarTrigger;

        inimigos.Add(new inimigoAtributos("inimigoMelee", 150, -2, 30, transform.position.x, transform.position.y, ativarTrigger));
        inimigos.Add(new inimigoAtributos("inimigoRanged", 100, -5, 15, transform.position.x, transform.position.y, ativarTrigger));

        
    }

   
    void Update()
    {
        for(int i = 0; i < 2; i++){
            if(gameObject.tag == listaTags[i]){
                im.movimentacao(inimigos[i], this);
            }
        }
        if(srInimigo.flipX){
            esquerda = true;
        }else{
            esquerda = false;
        }
        
        if(ia.vida <= 0){
            Destroy(this.gameObject);
        }
        int res = (int)player.instancia.transform.position.x - (int)transform.position.x;
        if(Mathf.Abs(rbInimigo.velocity.x) > 0){
            animInimigo.Play("andando");
        }else if(Mathf.Abs(res) < 3){
            animInimigo.Play("hitM");
        }else{
            animInimigo.Play("parado");
        }
        
       

    }

    public void inimigoTiro(){
        if(!GameObject.FindGameObjectWithTag("balaInimigo")){    
            Instantiate(goBala, new Vector2(transform.position.x, transform.position.y + 0.1f), 
            transform.localRotation);
            atirar = StartCoroutine(atirando());
        }
    }
    IEnumerator atirando(){
        yield return new WaitForSeconds(3);
    }

    void OnTriggerEnter2D(Collider2D colisao){
        
        if(colisao.gameObject.tag == "balaLaser"){
            ia.vida -= 2;
        }
        if(colisao.gameObject.tag == "balaPistola"){
            ia.vida -= 20;;
        }
        if(colisao.gameObject.tag == "balaRifle"){
            ia.vida -= 35;;
        }
        
    }

    
}


