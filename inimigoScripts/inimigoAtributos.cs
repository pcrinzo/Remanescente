using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoAtributos
{
    public string nome{get; set;}
    public float vida{get; set;}
    public float velocidade{get; set;}
    public float dano{get; set;}
    public float posX{get; set;}
    public float posY{get; set;}
    public int ativarTrigger{get; set;}

    public inimigoAtributos(){
       
    }

    public inimigoAtributos(string nome, float vida, float velocidade, float dano, float posX, float posY, int ativarTrigger){
        this.nome = nome;
        this.vida = vida;
        this.velocidade = velocidade;
        this.dano = dano;
        this.posX = posX;
        this.posY = posY;
        this.ativarTrigger = ativarTrigger;
    }
}
