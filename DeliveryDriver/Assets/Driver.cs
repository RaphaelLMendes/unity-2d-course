using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float fastSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = -Input.GetAxis("Horizontal")* steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")* moveSpeed * Time.deltaTime;

        if(moveAmount>0){
            Debug.Log("Forward");
            transform.Rotate(0,0,steerAmount);
        }else if(moveAmount<0){
            transform.Rotate(0,0,-steerAmount);
        }
        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log("Colided");
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="SpeedBoost"){
            Debug.Log("SPEED!!!");
            moveSpeed = fastSpeed;
        }
    }
}
