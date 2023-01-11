using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCampFire : MonoBehaviour
{
    
    //TİMER
    private float timer;
    [SerializeField] private float timerMax=2f;
    [SerializeField] private float HealthAmount=10f;
    [SerializeField] GameObject CampfireText;
    private GameObject PlayerObject;
    private ScPlayerDM PlayerDM;
    void Start()
    {
        CampfireText.SetActive(false);
        timer=timerMax;
    }
    void Update()
    {
        if(Input.GetButton("Fire1" ) && isPlayerEntered==true)
        {
            if(healState == false) healState=true;
            CampfireText.SetActive(false);
        }
        if(healState==true)
        {
            HealPlayer();
        }
    }

    private void HealPlayer()
    {
        timer=timer-Time.deltaTime;
        if(timer<=0f)
        {

            if(PlayerDM.getPlayerHealth() >= PlayerDM.getPlayerMaxHealth())
            {
                healState = false;
            }
        }
        PlayerDM.hurt(-1*HealthAmount);
        timer=timerMax;
        Debug.Log(PlayerDM.getPlayerHealth());
    }

    private bool isPlayerEntered=false;
    private bool healState=false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player Endered Campfire Region");
            PlayerObject = col.gameObject;
            PlayerDM = PlayerObject.GetComponent<ScPlayerDM>();

            CampfireText.SetActive(true);
            isPlayerEntered=true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == PlayerObject)
        {
            Debug.Log("Player Exited");
            CampfireText.SetActive(false);
            isPlayerEntered=false;
        }
    }
}
