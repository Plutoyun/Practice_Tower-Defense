using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //Indicates that a class or a struct can be serialized.
public class Wave  { 

    public GameObject enemy; // Enemy type
    public int count; // how many enemies in this wave
    public float rate; // Generation speed
	
}
