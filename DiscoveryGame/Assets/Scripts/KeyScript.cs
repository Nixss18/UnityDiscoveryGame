using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject key;
    public GameObject pickupKeyText;
    
    void OnTriggerStay(Collider other){
        if(other.CompareTag("MainCamera")){
            pickupKeyText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                key.SetActive(false);
                PressKeyToOpenDoors.keyFound = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
     if(other.CompareTag("MainCamera")){
         pickupKeyText.SetActive(false);
     }   
    }
}
