using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaAtributos
{
    public string tipoBala{get; set;}
    public int municaoArma{get; set;}
    public int municaoPente{get; set;}
    public int municaoTotal{get; set;}
    public int municaoMaxima{get; set;}
    public int dano{get; set;}

    public armaAtributos(){}

    public armaAtributos(string tipoBala, int municaoArma, int municaoPente, int municaoTotal, int municaoMaxima, int dano){
        this.tipoBala = tipoBala;
        this.municaoArma = municaoArma;
        this.municaoPente = municaoPente;
        this.municaoTotal = municaoTotal;
        this.municaoMaxima = municaoMaxima;
        this.dano = dano;
    }
}
