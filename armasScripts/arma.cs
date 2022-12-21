using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class arma : MonoBehaviour
{
    
    public GameObject[] goBala;
    string[] balas = {"balaLaser", "balaPistola", "balaRifle"};
    string[] armas = {"armaLaser", "armaPistola", "armaRifle"};
    public GameObject goArma;
    public Transform tfJogador;
    public GameObject goMunicaoAtual;
    public GameObject goMunicaoTotal;
    public GameObject goBtnAtirar;
    private SpriteRenderer sprArma;
    [HideInInspector]public TextMeshProUGUI txtMunicaoAtual;
    [HideInInspector]public TextMeshProUGUI txtMunicaoTotal;
    [HideInInspector]public Button btnAtirar;
    [HideInInspector]public Btn sptAtirar;
    public int balaAtual;
    public List<armaAtributos> armasJogo = new List<armaAtributos>(); 
    Coroutine recarregar;
    public static bool esquerda;
    
    void Start()
    {
        txtMunicaoAtual = goMunicaoAtual.GetComponent<TextMeshProUGUI>();
        txtMunicaoTotal = goMunicaoTotal.GetComponent<TextMeshProUGUI>();
        btnAtirar = goBtnAtirar.GetComponent<Button>();
        sptAtirar = goBtnAtirar.GetComponent<Btn>();
        sprArma = goArma.GetComponent<SpriteRenderer>();

        armasJogo.Add(new armaAtributos("balaLaser", 180, 180, 900, 900, 2));
        armasJogo.Add(new armaAtributos("balaPistola", 10, 10, 50, 50, 20));
        armasJogo.Add(new armaAtributos("balaRifle", 5, 5, 15, 15, 35));
        
        for(int i = 0; i < 3; i++){
            if(GameObject.Find(armas[i])){
                goArma = GameObject.Find(armas[i]);
                balaAtual = i;
            }  
        }
        mudarTextoMunicao(armasJogo[balaAtual].municaoArma, armasJogo[balaAtual].municaoTotal);
        sprArma = goArma.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
        if(goArma.name == "armaLaser" && Btn.nomeBtn == "Atirar"){
            armaMetodos.atirando2(goBala[balaAtual], this);
        }
        if(esquerda){
            transform.position = new Vector3(tfJogador.position.x, tfJogador.position.y + 0.7f, transform.position.z);
            sprArma.flipX = true;
        }else{
            transform.position = new Vector3(tfJogador.position.x + 0.7f, tfJogador.position.y + 0.7f, transform.position.z);
            sprArma.flipX = false;
        }
        
    }

    public void atirar(){
        if(goArma.name != "armaLaser" && goArma.name != "armas"){
            armaMetodos.atirando(goBala[balaAtual], this);
        }

    }

    public void recarregarArma(){
        recarregar = StartCoroutine(Recarregando());
        desativarBotoes();
    }

    IEnumerator Recarregando(){
        yield return new WaitForSeconds(0.1f);
        for(int i = armasJogo[balaAtual].municaoArma; i < armasJogo[balaAtual].municaoPente; i++){
            if(armasJogo[balaAtual].municaoTotal > 0){
                armasJogo[balaAtual].municaoArma += 1;
                armasJogo[balaAtual].municaoTotal -= 1;
            }
        }
        Btn.pressionando = false;
        StartCoroutine(ativarBtn());
        
        
    }

    IEnumerator ativarBtn(){
        yield return new WaitForSeconds(1);
        btnAtirar.enabled = true;
        sptAtirar.enabled = true;
        
        mudarTextoMunicao(armasJogo[balaAtual].municaoArma, armasJogo[balaAtual].municaoTotal);
    }


    public void recarregarRifle(){
        StartCoroutine(RecarregandoRifle(this));
    }
    IEnumerator RecarregandoRifle(arma a){
        yield return new WaitForSeconds(1);
        a.btnAtirar.enabled = true;
    }

    public void desativarBotoes(){
        btnAtirar.enabled = false;
        sptAtirar.enabled = false;
    }
    public void mudarTextoMunicao(int muniAtual, int muniTotal){
        txtMunicaoAtual.SetText(muniAtual.ToString());
        txtMunicaoTotal.SetText(muniTotal.ToString());

    }
}
