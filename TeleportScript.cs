using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(2);
        }
    }    

}
