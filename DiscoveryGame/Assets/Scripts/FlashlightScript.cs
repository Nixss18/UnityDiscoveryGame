using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{

    [SerializeField] GameObject flashlight, flashlight_player, flashlightText;

    void OnTriggerStay(Collider other){
        if(other.CompareTag("MainCamera")){
            print("I touched myself");
            flashlightText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                flashlight.SetActive(false);
                flashlight_player.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("MainCamera")){
            flashlightText.SetActive(false);
        }
    }
}
