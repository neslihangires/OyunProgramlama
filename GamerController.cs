using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GamerController : MonoBehaviour
{

    //Animatör
    private Animator p_Animator;


    //GameObjects
    private GameObject WeaponObj;

    //Components
    private Rigidbody2D playerRB;

    //Player Control Variable
    public float movementSpeet = 5.0f;
    public float weaponAwayRadius = 0.6f;
    private float weaponAngle;

    //Input Variables
    private float h_Input;
    private float v_Input;



    //Equip Weapon
    private bool isWeaponEquipped;

    void Awake()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
        isWeaponEquipped = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        p_Animator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update time:"+ Time.deltaTime);
        CheckInput();

    }
    //Frame-rate independent MonoBehaviour.
    //FixedUpdate message for calculations.
    void FixedUpdate()
    {
        //Debug.Log("Fixed Update Time:"+ Time.deltaTime);
        playerRB.velocity = new Vector2(h_Input*movementSpeet,v_Input*movementSpeet);
    }
    void LateUpdate()
    {
        
    }
    void CheckInput()
    {
        h_Input = Input.GetAxis("Horizontal"); //use pyhsical keys -1 ve 1 arası değer alır
        v_Input = Input.GetAxis("Vertical");
    //    Debug.Log("h_Input" + h_Input);

    //ANİMASYON KODLARI
        if(h_Input >0.1)
        {
            p_Animator.SetBool("walkR",true);
        }
        else if(h_Input == 0.0 )
        {
            p_Animator.SetBool("walkR",false);
        }
        if(h_Input <-0.1)
        {
            p_Animator.SetBool("walkL",true);
        }
        else if(h_Input == 0.0 )
        {
            p_Animator.SetBool("walkL",false);
        }
        if(v_Input >0.1)
        {
            p_Animator.SetBool("walkU",true);
        }
        else if(v_Input == 0.0 )
        {
            p_Animator.SetBool("walkU",false);
        }
        if(v_Input <-0.1)
        {
            p_Animator.SetBool("walkD",true);
        }
        else if(v_Input == 0.0 )
        {
            p_Animator.SetBool("walkD",false);
        }

    



        if(WeaponObj != null && isWeaponEquipped==true)
        {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - this.transform.position;//WeaponObj.transform.position;
        float angle = Vector2.SignedAngle(Vector2.right,direction);
        float angleRad = angle * Mathf.PI/180;
        weaponAngle=angle;


    //    Debug.Log("Angle:" +angle);
        WeaponObj.transform.eulerAngles = new Vector3(0,0,angle);
        WeaponObj.transform.localPosition = new Vector2(weaponAwayRadius*Mathf.Cos(angleRad),weaponAwayRadius*Mathf.Sin(angleRad));
        }
        if(isWeaponEquipped==true && Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Fire");
            if(WeaponObj != null)
            {
                WeaponObj.GetComponent<ScHandGun>().shoot(weaponAngle);
            }else{ Debug.LogError("Error: WeaponObj is"+WeaponObj); }
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(isWeaponEquipped==false && col.CompareTag("Weapon"))
        {
        Debug.Log("Trigerred Weapon Trigger");
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        WeaponObj = col.gameObject;
        col.gameObject.transform.parent.position = new Vector2(this.gameObject.transform.position.x+weaponAwayRadius,this.gameObject.transform.position.y);
        col.gameObject.transform.parent = this.gameObject.transform;
        isWeaponEquipped =true;
        }
   }
   
}

