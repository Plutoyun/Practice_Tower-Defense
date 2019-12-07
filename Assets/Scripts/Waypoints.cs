using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] points; // A list of the road points for enemies / Route map

    void Awake()
    {
        points = new Transform[transform.childCount]; //记录waypoints下的子物体的位置 Record the position of child objects under waypoints
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
