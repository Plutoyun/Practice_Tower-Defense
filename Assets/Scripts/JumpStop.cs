using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStop : MonoBehaviour { // Control animation clip on Hellephant to make sure the moving speed is associated with its jump

    private Enemy e;
    public float acceleration;
    private bool SpeedJump;

    private void Start()
    {
         e= this.GetComponent<Enemy>();
    }

    // Use this for initialization
    public void HellephantStop()
    {
        //Debug.Log("23333");
       
        e.speed = 0;
    }

    public void HellephantRemove()
    {
        e.speed = e.startSpeed;
    }

    public void HellephantJumpToMove()
    {
        //e.speed += acceleration * Time.deltaTime;
        //e.speed = e.startSpeed;
        SpeedJump = true;
    }

    public void HellephantJump()
    {
        e.speed = 0;
    }

    private void Update()
    {
        if (SpeedJump)
        {
            if (e.speed < e.startSpeed)
            {
                e.speed += acceleration * Time.deltaTime;
            }
            else
                e.speed = e.startSpeed;
        }
    }
}
