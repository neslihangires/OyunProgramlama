using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScHandGun : MonoBehaviour
{

    //GameObject for Bullet
   [SerializeField] private GameObject BulletGO;

    //Start Position for Bullet
   [SerializeField] private Transform bulletSpawnPoint;
    
    public void shoot(float angle)
    {
        if(BulletGO!=null)
        {
            Vector3 positionBullet = bulletSpawnPoint.position;
            Quaternion rotationBullet = Quaternion.Euler(0,0,BulletGO.transform.eulerAngles.z+angle);
            GameObject bullet = Instantiate(BulletGO, positionBullet, rotationBullet);

            bullet.GetComponent<ScHandGunBullet>().shootBullet(angle);
        }
        
    }
}
