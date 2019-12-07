using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]//挂这个组件的时候会自动挂组件Enemy Add Component "Enemy" at the same time 
public class EnemyMovement : MonoBehaviour
{

    private Transform target; 
    private int wavepointIndex = 0; // Target road points 
    private Enemy enemy; // Enemy instance

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0]; // Set destination
       
    }

    void Update()
    {
        if (enemy.isDead)
        {
            return;
        }
 
        Vector3 dir = target.position - transform.position; //前进方向，目标-现在 Set direction
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);//前进;并排除帧率的影响;世界坐标  Forward; and exclude frame rate effects; world coordinates
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Vector3 rotation = lookRotation.eulerAngles;//按照三个轴上的数值进行传输，但转动生硬，不平滑 
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;//lerp用来平滑移动 rotate smoothly
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);//只绕着Y轴 
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)//判断和标记点的距离（根据延迟和速度算）Whether arrives the destination
        {
            GetNextWaypoint();
        }

        // enemy.speed = enemy.startSpeed;

    }

    void GetNextWaypoint()
    {

        if (wavepointIndex >= Waypoints.points.Length - 1)  // if arrived destination
        {
            EndPath(); 
            return;
        }
        wavepointIndex++; // move towards next road point
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}

