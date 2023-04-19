using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPizza;

    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPizzaColor = new Color32(0,255,77,255);
    [SerializeField] Color32 noPizzaColor = new Color32(255,255,255,255);

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log("Colided");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Pizza" && !hasPizza){
            Debug.Log("PIZZA GOTTEN!!!");
            spriteRenderer.color = hasPizzaColor;
            hasPizza = true;
        }
        if(other.tag=="Customer" && hasPizza){
            Debug.Log("DELIVERED");
            hasPizza = false;
            spriteRenderer.color = noPizzaColor;
            Destroy(other.gameObject, destroyDelay);

            // triger new game loop
        }
    }
}
