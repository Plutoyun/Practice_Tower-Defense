using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour //Start scene's camera rotation and start button
{
    public Camera Cam;
    public SceneFader sceneFader;
    public string NextSceneName = "Main Scene";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线 Rey start from camera to click point
            RaycastHit hitInfo; // Clicked info 
            if (Physics.Raycast(ray, out hitInfo))//If clicked an object
            {
                //Debug.DrawLine(ray.origin, hitInfo.point);//划出射线，只有在scene视图中才能看到 Draw rays, only visible in scene view
                GameObject gameObj = hitInfo.collider.gameObject;
               // Debug.Log("click object name is " + gameObj.name);
                if (gameObj.tag == "start")//当射线碰撞目标为boot类型的物品 ，执行拾取操作 When the ray collides with item tagged "start", pick it up
                {
                    sceneFader.FadeTo(NextSceneName); //Load next scene
                    //SceneManager.LoadScene("Main Scene");
                    //Debug.Log("pick up!");

                }
            }
        }
    }
}