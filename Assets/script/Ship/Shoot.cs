using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootingDelay = 0.2f;
    [SerializeField] protected float shootingTimer = 0f;
    //[SerializeField] protected Transform bullet;

    void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();

    }
    protected virtual bool IsShooting()
    {
         this.isShooting = InputManager.Instance.OnFire == 1;
        return this.isShooting;
    }
    protected void Shooting()
    {
        this.shootingTimer += Time.fixedDeltaTime;
        if (shootingTimer < shootingDelay )return;

        if (!this.isShooting) return;

        this.shootingTimer = 0;
        ShootLv1();
        //ShootLv2();
        //ShootLv3();
    }
    protected void ShootLv1()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne,spawnPos, rotation);
        if (newBullet == null ) { return; }
        newBullet.gameObject.SetActive(true);
    }
    //protected void ShootLv2()
    //{
    //    Vector3 spawnPos = transform.parent.position;
    //    Quaternion rotation1 = transform.parent.rotation;
    //    rotation1.z += 0.05f;
    //    Quaternion rotation2 = transform.parent.rotation;
    //    rotation2.z -= 0.05f;
    //    Transform newBullet1 = BulletSpawner.Instance.Spawn(BulletSpawner.BulletTwo, spawnPos, rotation1);
    //    if (newBullet1 == null) { return; }
    //    Transform newBullet2 = BulletSpawner.Instance.Spawn(BulletSpawner.BulletTwo, spawnPos, rotation2);
    //    if (newBullet2 == null) { return; }

    //    newBullet1.gameObject.SetActive(true);
    //    newBullet2.gameObject.SetActive(true);
    //}
    //protected void ShootLv3()
    //{
    //    Vector3 spawnPos = transform.parent.position;
    //    Quaternion rotation1 = transform.parent.rotation;
    //    rotation1.z += 0.1f;
    //    Quaternion rotation2 = transform.parent.rotation;
    //    rotation2.z -= 0.1f;
    //    Transform newBullet1 = BulletSpawner.Instance.Spawn(BulletSpawner.BulletTwo, spawnPos, rotation1);
    //    if (newBullet1 == null) { return; }
    //    Transform newBullet2 = BulletSpawner.Instance.Spawn(BulletSpawner.BulletTwo, spawnPos, rotation2);
    //    if (newBullet2 == null) { return; }

    //    newBullet1.gameObject.SetActive(true);
    //    newBullet2.gameObject.SetActive(true);
    //}

}
