using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour { // Rotate camera

    public GameObject target;
    public float PanSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), PanSpeed * Time.deltaTime);
	}
}
