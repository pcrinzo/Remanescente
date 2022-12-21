using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaMetodos : MonoBehaviour
{
    
    public static void atirando(GameObject goBala, arma a){
        if(a.armasJogo[a.balaAtual].municaoArma > 0){
            if(arma.esquerda){
                Instantiate(goBala, new Vector2(a.transform.position.x - 0.6f, a.transform.position.y - 0.5f), 
                a.transform.localRotation);
            }else{
                Instantiate(goBala, new Vector2(a.transform.position.x + 0.6f, a.transform.position.y - 0.5f), 
                a.transform.localRotation);
            }
        
            a.armasJogo[a.balaAtual].municaoArma -= 1;
            a.mudarTextoMunicao(a.armasJogo[a.balaAtual].municaoArma, a.armasJogo[a.balaAtual].municaoTotal);
            if(a.balaAtual == 2){
                a.btnAtirar.enabled = false;
                a.recarregarRifle();
            }
        }else{
            a.recarregarArma();
        } 
    }

    public static void atirando2(GameObject goBala, arma a){
        if(Btn.pressionando && Btn.nomeBtn == "Atirar"){
            if(a.armasJogo[a.balaAtual].municaoArma > 0){
                if(arma.esquerda){
                    Instantiate(goBala, new Vector2(a.transform.position.x - 0.6f, a.transform.position.y - 0.5f), 
                    a.transform.localRotation);
                    Instantiate(goBala, new Vector2(a.transform.position.x - 0.10f, a.transform.position.y - 0.5f), 
                    a.transform.localRotation);
                }else{
                    Instantiate(goBala, new Vector2(a.transform.position.x + 0.6f, a.transform.position.y - 0.5f), 
                    a.transform.localRotation);
                    Instantiate(goBala, new Vector2(a.transform.position.x + 0.10f, a.transform.position.y - 0.5f), 
                    a.transform.localRotation);
                }
                
                a.armasJogo[a.balaAtual].municaoArma -= 1;
                a.mudarTextoMunicao(a.armasJogo[a.balaAtual].municaoArma, a.armasJogo[a.balaAtual].municaoTotal);
                }else{
                    a.recarregarArma();
                }
        }
    }
    
    
}
