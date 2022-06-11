using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyToOpenDoors : MonoBehaviour
{
  public GameObject Instruction, needKeyText;
  public GameObject AnimObject;
  public GameObject Trigger;
  public bool Action = false;
  public bool opened, locked; //nosaka vai durvim vajag atslegu

   // [SerializeField] AudioClip doorClip;
  public AudioSource Sfx; //soundeffects
  private SC_FPSController keys; //ja atrod atslēgu

  void Start(){
      Instruction.SetActive(false);
      needKeyText.SetActive(false);
      keys = FindObjectOfType<SC_FPSController>();
      //sfx = GetComponent<AudioSource>();
  }

  void OnTriggerEnter(Collider collision){
     
    if(collision.transform.tag == "Player" && keys.KeyAmount < 1){
        Instruction.SetActive(true);
        if(locked == true){
            Instruction.SetActive(false);
            needKeyText.SetActive(true);
        }
        Action = true;
    }
    else if (collision.transform.tag == "Player" && keys.KeyAmount == 1){
        Instruction.SetActive(true);
        Action = true;
       
    }
  }

  void OnTriggerExit(Collider collision){
      Instruction.SetActive(false);
      needKeyText.SetActive(false);
      Action = false;
  }

  void Update(){
      if(opened == true){
        if(Input.GetKeyDown(KeyCode.E)){
               // sfx.PlayOneShot(doorClip);
            if(Action == true){
                Sfx.Play();
                Instruction.SetActive(false);
                AnimObject.GetComponent<Animator>().Play("DoorOpen");
                Trigger.SetActive(false);
                Action = false;
            }
           
        }
      }

    else if(locked == true && keys.KeyAmount >=1){
        if(Input.GetKeyDown(KeyCode.E)){
            if(Action == true){
                Sfx.Play();
                Instruction.SetActive(false);
                AnimObject.GetComponent<Animator>().Play("DoorOpen");
                Trigger.SetActive(false);
                Action = false;
                keys.KeyAmount -= 1;
            }
           
        }
      }
  }


}


