using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoMetodos
{
    
    private int[] layerMasks = {1 << 7, 1 << 8};
    private int layer;
    private int distanciaInimigoTrigger;

    //função para a movimentação dos inimigos
    public void movimentacao(inimigoAtributos ia, inimigo i){
        colisao(i);
        if(layer == layerMasks[0]){
            i.rbInimigo.velocity = new Vector2(direcaoAtiva(ia, i), i.rbInimigo.velocity.y);
        }else if(layer == layerMasks[1]){
            i.rbInimigo.velocity = new Vector2(direcaoDesativa(ia, i), i.rbInimigo.velocity.y);
        }
    }

    //função para ativar o movimento dos inimigos
    private float direcaoAtiva(inimigoAtributos ia, inimigo i){
        int res = (int)player.instancia.transform.position.x - (int)i.transform.position.x;
        float direcao = 0;
        
        if(res < -2 && Mathf.Abs(distanciaInimigoTrigger) <= ia.ativarTrigger){
            direcao = ia.velocidade;
            i.srInimigo.flipX = true;
            if(i.gameObject.tag == "inimigoMelee"){
                i.bcInimigoPadrao.enabled = true;           
            }
            

        }else if(res > 2 && Mathf.Abs(distanciaInimigoTrigger) <= ia.ativarTrigger){
            direcao = Mathf.Abs(ia.velocidade);
            i.srInimigo.flipX = false;
            if(i.gameObject.tag == "inimigoMelee"){
                i.bcInimigoPadrao.enabled = true;           
            }
            
            
        }else{
            if(inimigo.esquerda){
                i.bcInimigoEsquerda.enabled = true;
                i.bcInimigoDireita.enabled = false;
                i.bcInimigoPadrao.enabled = false;
            }else{
                i.bcInimigoDireita.enabled = true;
                i.bcInimigoEsquerda.enabled = false;
                i.bcInimigoPadrao.enabled = false;
            }
            return 0;
        }
        
        if(ia.nome == "inimigoRanged"){
            if(Mathf.Abs(res) <= 7 && Mathf.Abs(res) > 0){
                i.inimigoTiro();  
                return 0;
            }
        }
        
        return direcao;
    }
    //função para fazer os inimigos voltarem pra posição original
    private float direcaoDesativa(inimigoAtributos ia, inimigo i){
        int res = (int)ia.posX - (int)i.transform.position.x;
        float direcao = 0;
        if(res < 0){
            direcao = ia.velocidade;
            i.srInimigo.flipX = true;
        }else if(res > 0){
            direcao = Mathf.Abs(ia.velocidade);
            i.srInimigo.flipX = false;
        }
        return direcao;
    }

    

    //função para colisao
    private void colisao(inimigo im){
        for(int i = 0; i <= 1; i++){
            RaycastHit2D rcTrigger;
            if(player.instancia.bcPlayerEsquerda.enabled == true){
                rcTrigger = Physics2D.BoxCast(player.instancia.bcPlayerEsquerda.bounds.center, 
                player.instancia.bcPlayerEsquerda.bounds.size, 0, Vector2.down, 0.1f, layerMasks[i]);
            }else{
                rcTrigger = Physics2D.BoxCast(player.instancia.bcPlayerEsquerda.bounds.center, 
                player.instancia.bcPlayerDireita.bounds.size, 0, Vector2.down, 0.1f, layerMasks[i]);
            }
            if(rcTrigger.collider != null){
                layer = layerMasks[i];
                distanciaInimigoTrigger = (int)im.transform.position.x - (int)player.instancia.transform.position.x;
            }
        }
    }
}
