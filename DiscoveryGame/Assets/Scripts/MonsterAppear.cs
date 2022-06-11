using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAppear : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject monster;
    public Collider collision;

    public GameObject monsterTrigger;
    [SerializeField] public int timer;

    public AudioSource sfx;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            sfx.Play();
            monster.SetActive(true);
            collision.enabled = false;
            StartCoroutine(HideObject()); //korutīna
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("MonsterTrigger")){
            monsterTrigger.SetActive(false);
        }
    }

    IEnumerator HideObject(){ //korutīna, kas pēc taimera izslēdz monstru
        yield return new WaitForSeconds(timer);
        monster.SetActive(false);
            
    }
}
