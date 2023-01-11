using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ScEnemyController : MonoBehaviour
{

    [SerializeField] private GameObject PlayerGo;
    [SerializeField] private GameObject SoulGo;
    [SerializeField] private GameObject pirate_coin;
    private Transform PlayerT;
    private Vector2 HomePos;
    private Vector2 MovmentDir;

    UnityEngine.AI.NavMeshAgent agent;


    
    private float h_Input;
    private float v_Input;

    private float TargeDist;
    public float fallowRange=8f;
    //ANİMATÖR
    private Animator enemyChickenAnim;

    
    [SerializeField] public float EnemyHurtDamage=20f;
    [SerializeField] private float max_Health = 100f;
    [SerializeField] private float min_Health = 0f;
    [SerializeField] private float curr_Health = 60f;
    [SerializeField] private GameObject BloodEffects;

    void Start()
    {
        if ( PlayerGo == null )        
        PlayerGo = GameObject.FindWithTag("Player");

        PlayerT = PlayerGo.transform;
        HomePos = new Vector2(this.transform.position.x, this.transform.position.y);
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation=false;
        agent.updateUpAxis = false;
        enemyChickenAnim = this.GetComponent<Animator>();

    }

   
   void Update()
   {
    TargeDist = Vector2.Distance(PlayerT.position, this.transform.position);
    if(TargeDist <= fallowRange)
   {
        agent.SetDestination(PlayerT.position);
   }
    else
    {
        agent.SetDestination(HomePos);
    }
    MovmentDir=agent.velocity/agent.speed;
    float magn=Mathf.Sqrt (MovmentDir.x*MovmentDir.x+MovmentDir.y*MovmentDir.y);
    if(magn>0.015f)
    {
        enemyChickenAnim.SetBool("IsIdle",false);
        enemyChickenAnim.SetFloat("MovX", MovmentDir.x);
        enemyChickenAnim.SetFloat("MovY", MovmentDir.y);
    }
    else
    {
        enemyChickenAnim.SetBool("IsIdle",true);
    }
   }


    void OnTriggerEnter2D(Collider2D col)
    {


        if(col.CompareTag("Bullet"))
        {
//            Instantiate(BloodEffects, col.gameObject.transform.position, Quaternion.identity);
            float damage=col.gameObject.GetComponent<ScHandGunBullet>().getBulletDamage();
            this.setHealth(this.getCurrHealth()-damage);
            Debug.Log("Enemy Current Health:"+this.getCurrHealth());

            if(this.getCurrHealth() <= 0f)
            {
                //Spirint 
                float chance = Random.Range(0.0f, 100.0f);
                if(chance <= 100)
                {
                Instantiate(SoulGo,this.transform.position, Quaternion.identity);
                }
//                else
//                {
//                Instantiate(pirate_coin,this.transform.position, Quaternion.identity);
//                }
                Instantiate(BloodEffects,this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);

            }
        }

    }
    public float getEnemyHurtDamage(){ return EnemyHurtDamage; }// methot ile çekebilmek 
    
    
    public float getMinHealth(){ return this.min_Health; }
    public float getCurrHealth(){ return this.curr_Health; }
    public void setHealth(float HealthAmount)

    {
    if(HealthAmount> this.max_Health)
        this.curr_Health=this.max_Health;
    else
        this.curr_Health = HealthAmount;
    }

}
