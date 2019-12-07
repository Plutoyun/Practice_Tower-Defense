using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]//用来显示在属性窗口 General attributes

    public float range = 15f; // facous range

    [Header("Use Bullets(default)")]
    public GameObject bulletPrefab; //Bullet typr
    public float fireRate = 1f; // Fire speed
    private float fireCountdown = 0f; // used to calculate fire rate

    [Header("Use Laser")] // Attributes for turret type is laser
    public bool useLaser = false;

    public int damageOverTime = 30; //Damage cost per second

    public float slowAmount = 0.5f; // Slow target's speed
    public LineRenderer lineRenderer; // Laser style 
    //public LineRenderer lineRenderer_2;
    public ParticleSystem impactEffect;
    public Light impactLight; // light effect when impact

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy"; //Target tag
    public Transform PartToRotate; // Rotation part in model
    public float turnSpeed = 10f; //Ratation speed
    public Transform firepoint; // fire point
    [Header("Optional")]
    public Transform firepoint_2; //For level 3 laser which has two fire points



	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // Update rate for searching target
        
    }

    void UpdateTarget()  //寻找最近敌人  减少电脑负担，每两帧运行一次 Find nearest enemies; Reduce computer load, run every two frames
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && enemy.GetComponent<Enemy>().isDead == false)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            
            return;
        }

        LockOnTarget();
        //控制朝向最近目标  有时出现始终相差一定角度的错误，建立一个空物体来进行矫正
        // Look towards the nearest target. Sometimes an error always occurs at a certain angle. Create an empty object to correct it.
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <=0f)
                    {
                        Shoot();
                        fireCountdown = 1f / fireRate;
                    }

            fireCountdown -= Time.deltaTime;
        }

        
	}

    void LockOnTarget()
    {
        //Vector3 angleRange = new Vector3(0, AngleRange, 0);
        Vector3 dir = target.position - transform.position;//角度目标向量 B-A Angle target vector B-A
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Vector3 rotation = lookRotation.eulerAngles;//按照三个轴上的数值进行传输，但转动生硬，不平滑 Rotate according to the values on the three axes, but the rotation is stiff and not smooth
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;//lerp用来平滑移动 Rotate smoothly
        PartToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f); //Quaternion.Euler(0f, rotation.y, 0f);//只绕着Y轴  Rotate around Y axis only

    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);


        if (!lineRenderer.enabled) // Simulation on lasers
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        //Draw laser effect from fire point to target
        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, target.position+ new Vector3 (0,1,0));
        if (firepoint_2 != null) // If turret has two fire points
        {
            Vector3 dirc = transform.position - target.position;
            lineRenderer.SetPosition(0, target.position + new Vector3(0, 1, 0));
            lineRenderer.SetPosition(1, firepoint_2.position);
            lineRenderer.SetPosition(2, firepoint_2.position + dirc.normalized);
            lineRenderer.SetPosition(3, firepoint.position + dirc.normalized);
            lineRenderer.SetPosition(4, firepoint.position);
            lineRenderer.SetPosition(5, target.position + new Vector3(0, 1, 0));
        }

        Vector3 dir = firepoint.position - target.position;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        impactEffect.transform.position = target.position + new Vector3(0, 1, 0) + dir.normalized* 0.4f; 
    }

    void Shoot()
    {
        //死亡之后不在攻击；Not attacking after target died

        GameObject bulletGo =(GameObject) Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
        
    }


     void OnDrawGizmosSelected()//Gizmos类 用于在场景中辅助显示 每一帧都显示 Used for auxiliary display in the scene
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
