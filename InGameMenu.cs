using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject InGameGUIObj;
    [SerializeField] private GameObject InGameMenuObj;

    bool isPause=false;

    // Start is called before the first frame update
    void Start()
    {
        isPause=false;
        InGameMenuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.P))
    {
        button_ContinuePauseToggle();
    }
    }

    public void button_ContinuePauseToggle()
    {
        if(isPause==false)
        {
        Time.timeScale=0f;
        InGameMenuObj.SetActive(true);
        isPause=true;
        }
        else
        {
        Time.timeScale=1f;
        isPause=false;
        }
    }

    public void button_MenuExıt()
    {
        isPause = false;
        Time.timeScale=1f;
        InGameMenuObj.SetActive(false);
    }
}
