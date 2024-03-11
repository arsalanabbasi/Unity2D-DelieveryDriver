using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed= 15f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float bumpSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Setting up Up-Down movements
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //Reverse speed is slower than forward speed
        if (Input.GetAxis("Vertical") < 0){
            moveAmount *= 0.5f;
        }
        
        //Setting up Left-Right movement
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //Can't steer in no move speed
        if(moveAmount == 0)
            steerAmount = 0;
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other){
        moveSpeed = bumpSpeed;
        }


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
            Debug.Log("Speed Boosted!");
            }
        
        }
}
