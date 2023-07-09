using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class WandererBrain : Singleton<WandererBrain>
{
    public EnemyBrain FindClosestEnemy()
    {
        EnemyBrain[] gos;
        gos = Enemies.Instance.enemiesList.ToArray();
        EnemyBrain closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (EnemyBrain go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    public bool CanShoot = false;
    public float CanShootTimer;
    private void Start()
    {
        ResetShootTimer();
    }

    public void ResetShootTimer()
    {
        if (WandererStats.Instance.CurrentWeapon != null)
            CanShootTimer = 1 / WandererStats.Instance.CurrentWeapon.stats.attackSpeed;
    }

    public EnemyBrain closestEnemy;

    private void Update()
    {
        if (!CanShoot)
        {
            CanShootTimer -= Time.deltaTime;
        }
        if (CanShootTimer <= 0)
        {
            CanShoot = true; ResetShootTimer();
        }


        if (WandererStats.Instance.CurrentWeapon == null)
        {
            return;
        }
        if (Enemies.Instance.enemiesList.Count == 0)
        {
            WandererStats.Instance.CurrentWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            WandererStats.Instance.CurrentWeapon.sr.flipY = false;
            return;
        }

        closestEnemy = FindClosestEnemy();
        if (closestEnemy.transform.position.x > transform.position.x)
        {
            WandererStats.Instance.CurrentWeapon.sr.flipY = false;
        }
        else
        {
            WandererStats.Instance.CurrentWeapon.sr.flipY = true;
        }
        if (Vector2.Distance(closestEnemy.transform.position, transform.position) < WandererStats.Instance.CurrentWeapon.stats.shootingRange)
        {
            WandererStats.Instance.CurrentWeapon.transform.right = closestEnemy.transform.position - WandererStats.Instance.CurrentWeapon.transform.position;
            WandererStats.Instance.CurrentWeapon.sr.flipX = false;
        }



        if (CanShoot)
        {


            if (Vector2.Distance(closestEnemy.transform.position, transform.position) < WandererStats.Instance.CurrentWeapon.stats.shootingRange)
            {
                WandererStats.Instance.CurrentWeapon.transform.right = closestEnemy.transform.position - WandererStats.Instance.CurrentWeapon.transform.position;
                WandererStats.Instance.CurrentWeapon.ShootBullet();
                CanShoot = false;
            }
        }



    }

}


