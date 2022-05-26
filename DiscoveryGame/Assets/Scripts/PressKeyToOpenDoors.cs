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

  void Start(){
      Instruction.SetActive(false);
  }

  void OnTriggerEnter(Collider collision){
      if(collision.transform.tag == "Player"){
          Instruction.SetActive(true);
          if(locked == true){
            needKeyText.SetActive(true);
          }
          Action = true;
      }
  }

  void OnTriggerExit(Collider collision){
      Instruction.SetActive(false);
      Action = false;
  }

  void Update(){
      if(locked == false){
        if(Input.GetKeyDown(KeyCode.E)){
            if(Action == true){
                Instruction.SetActive(false);
                AnimObject.GetComponent<Animator>().Play("DoorOpen");
                Trigger.SetActive(false);
                Action = false;
            }
        }
      }
  }
}

//     void OnTriggerStay(Collider other){
//         if(other.CompareTag("Player")){
//             if(opened == false){
//                 if(locked == false){
//                     Instruction.SetActive(true);
//                     if(Input.GetKeyDown(KeyCode.E)){
//                         AnimObject.GetComponent<Animator>().Play("DoorOpen");
//                         opened = true;
//                     }
//                 }
//                 if(locked == true){
//                     needKeyText.SetActive(true);
//                 }
//             }
//         }
//     }

//     void OnTriggerExit(Collider other){
//         if(other.CompareTag("Player")){
//             Instruction.SetActive(false);
//             needKeyText.SetActive(false);
//         }
//     }
// }
