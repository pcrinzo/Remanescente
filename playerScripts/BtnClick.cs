using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{

    public static string nomeBtn;
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
   
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        nomeBtn = gameObject.name;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
   
    }
}
