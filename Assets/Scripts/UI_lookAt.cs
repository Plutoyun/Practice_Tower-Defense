using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_lookAt : MonoBehaviour {
    public Transform Camera;
    public float DirX = 0;
    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LookAtCamera();
    }

    void LookAtCamera()
    {
        Vector3 dir = Camera.position - transform.position;//角度目标向量 B-A
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;//lerp用来平滑移动
        transform.rotation = Quaternion.Euler(DirX, rotation.y, 0f);//只绕着Y轴
    }
}
