using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string scene;
    void Update(){
        if(Input.GetKey(KeyCode.L)){
            SceneManager.LoadScene(scene); //uzsāk spēli
        }
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit(); //iziet ārā no spēles
        }
    }
}
