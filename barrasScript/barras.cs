using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class barras : MonoBehaviour
{
    public static barras instancia;
    [SerializeField] private GameObject goVida;
    [SerializeField] private GameObject goStamina;
    [HideInInspector] public SpriteRenderer srVida;
    [HideInInspector] public SpriteRenderer srStamina;
    public Sprite[] spritesStamina;
    public Sprite[] spritesVida;
    void Start()
    {
        instancia = this;
        srVida = goVida.GetComponent<SpriteRenderer>();
        srStamina = goStamina.GetComponent<SpriteRenderer>();

        srStamina.sprite = spritesStamina[0];
        srVida.sprite = spritesVida[0];
    }

   
    void Update()
    {
    
    }
}
