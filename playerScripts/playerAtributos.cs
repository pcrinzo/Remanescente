using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerAtributos
{   
    
    public float vida{get; set;}
    public float velocidade{get; set;}
    public float dash{get; set;}
    public float pulo{get; set;}
    public float stamina{get; set;}
    public float dcStamina{get; set;}
    public bool isDashing{get; set;}
    public float recarregaStamina{get; set;}
    public bool esquerda{get; set;}

    public playerAtributos(){
        this.vida = 100;
        this.velocidade = 5;
        this.dash = 15;
        this.pulo = 6;
        this.stamina = 100;
        this.dcStamina = 30;
        this.recarregaStamina = 20;
    }

    public playerAtributos(float vida, float velocidade, float dash, float pulo, float stamina, float dcStamina,
    bool isDashing, float recarregaStamina, bool esquerda){
        this.vida = vida;
        this.velocidade = velocidade;
        this.dash = dash;
        this.pulo = pulo;
        this.stamina = stamina;
        this.dcStamina = dcStamina;
        this.isDashing = isDashing;
        this.recarregaStamina = recarregaStamina;
        this.esquerda = esquerda;
    }
}
