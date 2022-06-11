using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2Appear : MonoBehaviour
{
    public GameObject monster;
    public AudioSource sfx;

    public GameObject monsterTrigger;

     [SerializeField] public int timer;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            sfx.Play();
            monster.SetActive(true);
            StartCoroutine(HideObject());
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            monster.SetActive(false); //ja speletajs iziet arpus triggera vins paslepj monstru
            monsterTrigger.SetActive(false); //izslēdz triggeri
        }
    }

    IEnumerator HideObject(){ //korutīna, kas pēc taimera izslēdz monstru
        yield return new WaitForSeconds(timer);
        monster.SetActive(false);
            
    }
}
