using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpItem : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
           
            

            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0) { // verifica se o slot esta vazio 
                    inventory.items[i] = 1; // garante que o slot esteja cheio 
                    Instantiate(itemButton, inventory.slots[i].transform, false); 
                    Destroy(gameObject);
                    break;
                }
            }
        }
        
    }
}