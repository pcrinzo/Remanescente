using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class playerMetodos
{
    public playerAtributos pa = new();  
    delegate T movimentacaoED<T>(T xy);
    delegate T movimentacaoPD<T>(T xy);
    private int[] vsBarras = {100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0, -10};
    public int[] layerMasks = {1 << 3, 1 << 6, 1 << 9, 1 << 10};
    private float[] plAtributos = {0, 0};
    //função para movimentação do personagem
    public void movimentar(player p, string nomeBtn){
        List<movimentacaoED<float[]>> listaMovimentosED = new List<movimentacaoED<float[]>>();
        listaMovimentosED.Add(andarEsquerda);
        listaMovimentosED.Add(andarDireita);
        //for para chamar as funções se o input for GetButton e fazer a movimentação
        if(Btn.pressionando && !pa.isDashing){
            foreach(movimentacaoED<float[]> movimento in listaMovimentosED){
                plAtributos[0] = p.rbPlayer.velocity.x;
                plAtributos[1] = p.rbPlayer.velocity.y;
                if(nomeBtn == movimento.Method.Name){
                    plAtributos = movimento(plAtributos);
                }
                p.rbPlayer.velocity = new Vector2(plAtributos[0], plAtributos[1]);
                p.srPlayer.flipX = pa.esquerda;       
            }
        }else if(BtnClick.nomeBtn != "dash"){
            parar(p);
        }

    }
    public void movimentar2(player p, string nomeBtn){
        List<movimentacaoPD<float[]>> listaMovimentosPD = new List<movimentacaoPD<float[]>>();
        listaMovimentosPD.Add(pular);
        listaMovimentosPD.Add(dash);    
        //for para chamar as funções se o input for GetButtonDown e fazer a movimentação
        foreach(movimentacaoPD<float[]> movimento in listaMovimentosPD){
            if(nomeBtn == movimento.Method.Name && !pa.isDashing && colisao(p, layerMasks[0])){
                plAtributos[0] = p.rbPlayer.velocity.x;
                plAtributos[1] = p.rbPlayer.velocity.y;
                plAtributos = movimento(plAtributos);
                p.rbPlayer.velocity = new Vector2(plAtributos[0], plAtributos[1]);
            }
        }
        //parar o dash
        if(colisao(p, layerMasks[2])){
            Debug.Log("aeio");
            pa.isDashing = false;
            p.pararDash(pa);
        }
    }
    //função para andar para esquerda
    private float[] andarEsquerda(float[] xy){ 
        float[] atributos = {0, 0};
        atributos[0] = -pa.velocidade;
        atributos[1] = xy[1];
        pa.esquerda = true;
        adBoxColliderEsquerda();
        arma.esquerda = true;
        return atributos;
    }
    //função para andar para direita
    private float[] andarDireita(float[] xy){
        float[] atributos = {0, 0};
        atributos[0] = pa.velocidade;
        atributos[1] = xy[1];
        pa.esquerda = false;
        adBoxColliderDireta();
        arma.esquerda = false;
        return atributos;
    }
    //função para pular
    private float[] pular(float[] xy){
        float[] atributos = {0, 0};
        if(pa.stamina >= pa.dcStamina){
            atributos[0] = xy[0];
            atributos[1] = pa.pulo;
            pa.stamina -= pa.dcStamina;
            return atributos;
        }
        return atributos;
    }
    //função para o dash
    private float[] dash(float[] xy){
        if(!pa.isDashing && pa.stamina >= pa.dcStamina){
            pa.isDashing = true;
            player.instancia.iniciarDash(pa);
        }
        float[] atributos = {0, 0};
        if(pa.isDashing && pa.esquerda == false ){
            atributos[0] = pa.dash;
            atributos[1] = xy[1];
            return atributos;
        }else if(pa.isDashing){
            atributos[0] = -pa.dash;
            atributos[1] = xy[1];
            return atributos;
        }
        return atributos;
    }
    //função para parar o personagem
    private float parar(player p){
        p.rbPlayer.velocity =  new Vector2(0, p.rbPlayer.velocity.y);
        return 1;
    }
    //trocar o box collider
    public void adBoxColliderEsquerda(){
        player.instancia.bcPlayerEsquerda.enabled = true;
        player.instancia.bcPlayerDireita.enabled = false;
    }
    //trocar o box collider
    public void adBoxColliderDireta(){
        player.instancia.bcPlayerEsquerda.enabled = false;
        player.instancia.bcPlayerDireita.enabled = true;
    }
    //função para a stamina do personagem
    public void barraStamina(){  
        //recarrega a stamina
        if(pa.stamina < 100){
            float staminaRecarga = Time.deltaTime * pa.recarregaStamina;
            pa.stamina += staminaRecarga;
        }
        //muda o sprite da barra de stamina
        for(int i = 0; i <= 10; i++){
            if(i == 0){
                if((int)pa.stamina >= vsBarras[i]){
                barras.instancia.srStamina.sprite = barras.instancia.spritesStamina[i];
                }
            }else if((int)pa.stamina >= vsBarras[i] && (int)pa.stamina < vsBarras[i-1]){
                barras.instancia.srStamina.sprite = barras.instancia.spritesStamina[i];
            }
        }
    }
    //função para a vida do personagem
    public void barraVida(player p){
        //da dano no personagem se ele colidir com um inimigo
        /*
        if(colisao(p, layerMasks[1])){
            pa.vida -= 10;
        }*/

        if(player.inimigoMeleeHit){
            pa.vida -= 30;
            player.inimigoMeleeHit = false;
        }
        if(balaInimigo23.balaColisao){
            pa.vida -= 15; 
            balaInimigo23.balaColisao = false;
        }
        //muda o sprite da barra de vida
        for(int i = 0; i <= 10; i++){
            if(i == 0){
                if((int)pa.vida >= vsBarras[i]){
                    barras.instancia.srVida.sprite = barras.instancia.spritesVida[i];
                }
            }else if((int)pa.vida >= vsBarras[i] && (int)pa.vida < vsBarras[i-1]){
                barras.instancia.srVida.sprite = barras.instancia.spritesVida[i];
            }
        }
        if((int)pa.vida <= 0){
            barras.instancia.srVida.sprite = barras.instancia.spritesVida[10];
            SceneManager.LoadScene("GameOver");
        }
    }

    //função para as colisões do personagem
    public bool colisao(player p, int layermask){
        RaycastHit2D rcColisao;
        if(p.bcPlayerEsquerda.enabled == true){
            rcColisao = Physics2D.BoxCast(p.bcPlayerEsquerda.bounds.center, 
            p.bcPlayerEsquerda.bounds.size, 0, Vector2.down, 0.1f, layermask);
        }else{
            rcColisao = Physics2D.BoxCast(p.bcPlayerDireita.bounds.center, 
            p.bcPlayerDireita.bounds.size, 0, Vector2.down, 0.1f, layermask);
        }
        return rcColisao.collider != null;
    }



    

    
    
    

   
}
