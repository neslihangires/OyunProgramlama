using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScLevel0GUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button_NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void button_Load()
    {

    }

    public void button_Settings()
    {

    }

    public void button_Exit()
    {
        Application.Quit();
    }
}
