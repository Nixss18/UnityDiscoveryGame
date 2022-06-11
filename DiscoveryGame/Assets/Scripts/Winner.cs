using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    
    public GameObject Instruction;

    void Start(){
        Instruction.SetActive(false);
    }
    public void OnTriggerEnter(){
        Instruction.SetActive(true);
    }
}
