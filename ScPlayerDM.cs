using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScPlayerDM : MonoBehaviour
{
    private ScPlayerData Player1Data;

    //Gui Elements
    [SerializeField] private GameObject HealthBarObj;
    [SerializeField] private GameObject ExpBarObj;
    [SerializeField] private GameObject SoulScoreObj;
    [SerializeField] private GameObject CoinScoreObj;
    [SerializeField] private GameObject LwlObj;

    private TextMeshProUGUI HealthScoreTxt;
    private TextMeshProUGUI ExpScoreTxt;
    private TextMeshProUGUI SoulScoreTxt;
    private TextMeshProUGUI CoinScoreTxt;
    private TextMeshProUGUI LwlTxt;

    public void increaseScore(){Player1Data.increaseScore();}
    public float getPlayerHealth(){ return Player1Data.getCurrHealth();}
    public float getPlayerMaxHealth(){ return Player1Data.getMaxHealth();}
    public float getCoin(){ return Player1Data.getCoin();}
    public void increaseCoin(){Player1Data.increaseCoin();}

    void Start()
    {
        Player1Data = new ScPlayerData();

        HealthScoreTxt = HealthBarObj.GetComponent<TextMeshProUGUI>();
        ExpScoreTxt = ExpBarObj.GetComponent<TextMeshProUGUI>();
        SoulScoreTxt = SoulScoreObj.GetComponent<TextMeshProUGUI>();
        CoinScoreTxt = CoinScoreObj.GetComponent<TextMeshProUGUI>();
        LwlTxt = LwlObj.GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {

        SoulScoreTxt.text = Player1Data.getScore().ToString();
        CoinScoreTxt.text = Player1Data.getCoin().ToString();
        LwlTxt.text = Player1Data.getLwl().ToString();
        HealthScoreTxt.text = Player1Data.getCurrHealth().ToString();
        ExpScoreTxt.text = Player1Data.getExp().ToString();


        if(Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Player1Data.setHealth(Player1Data.getCurrHealth()+10f);
            Debug.Log("Player Current Health: "+Player1Data.getCurrHealth());
        }
        if(Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Player1Data.setHealth(Player1Data.getCurrHealth()-10f);
            Debug.Log("Player Current Health: "+Player1Data.getCurrHealth());
        }
        if(Player1Data.getCurrHealth()<Player1Data.getMinHealth())
        {
            this.gameObject.SetActive(false); //Curr_Health negatif olunca player'i öldür
            Time.timeScale=0f;
            //Destroy(this.gameObject);
        }
    }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
            Debug.Log("Player Enemy ile çarpişiyor");

            ScEnemyController enemyContr;
            enemyContr = col.gameObject.GetComponent<ScEnemyController>(); //method çekmek
            enemyContr.getEnemyHurtDamage();
            this.hurt(enemyContr.getEnemyHurtDamage());
            }
            }
            public void hurt(float amount)
            {
            Player1Data.setHealth(Player1Data.getCurrHealth()-amount);
            Debug.Log("Player Current Health" +Player1Data.getCurrHealth());
        }

        void OnTriggerEnter2D(Collider2D col)
        {
        if(col.CompareTag("Coin"))
        {
            Player1Data.increaseCoin();
            Debug.Log("Coin count:"+ getCoin());
            Destroy(col.gameObject);
        }
        if(col.CompareTag("Spirit"))
        {
            Player1Data.increaseScore();
            Player1Data.increaseExp();
            if(Player1Data.getExp() >= 100)
            {
                Player1Data.increaseLwl();
                Player1Data.resetExp();
            }
            Debug.Log("Soul Count:"+ Player1Data.getScore());
            Destroy(col.gameObject);
        }
        }
}
