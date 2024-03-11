using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
   [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
   [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
   [SerializeField] float destroyDelay = 0.5f;
   
   bool hasPackage = false;
   SpriteRenderer spriteRenderer;

   void Start(){
      spriteRenderer = GetComponent<SpriteRenderer>();
   }

   void OnCollisionEnter2D(Collision2D other) {
    Debug.Log("Hit!");
   }

   void OnTriggerEnter2D(Collider2D other) {
    

    if(other.tag == "Package" && !hasPackage){
      Debug.Log("Package Picked-up!");
      hasPackage = true;
      Destroy(other.gameObject, destroyDelay);
      
      //Change Car color to green when package is picked-up
      spriteRenderer.color = hasPackageColor;
      }
   
   else if(other.tag == "Customer" && hasPackage){
      Debug.Log("Package Delieverd!");
      hasPackage = false;

      //Change Car color to default when package dropped-off
      spriteRenderer.color = noPackageColor;  
      }

   }
}
