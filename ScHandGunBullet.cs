using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScHandGunBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamage=50f;
//    [SerializeField] float bulletLifeTime=0.5f;

    public void shootBullet(float angle)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed*Mathf.Cos(angle*Mathf.PI/180),bulletSpeed*Mathf.Sin(angle*Mathf.PI/180));


    }
    public float getBulletDamage(){ return bulletDamage; }

//    void OnBecameInvisible()
//    {
//        //Debug.Log("Bullet is out of screen");
//        Destroy(this.gameObject, bulletLifeTime);
//    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Bullet - " + col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
       
       
        if(col.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
        if(col.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    
    }


}
