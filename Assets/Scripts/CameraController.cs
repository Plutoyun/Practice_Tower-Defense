
using UnityEngine;

public class CameraController : MonoBehaviour // Move camera
{

    //  private bool doMovement = false;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    private float ry;
    private float rz;


    // Update is called once per frame
    void Update()
    {

        if (Gamemanger.GameIsOver)
        {
            this.enabled = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }*/
        ry = transform.localEulerAngles.y;
        rz = transform.localEulerAngles.z;


        if (Input.GetKey("a"))//|| Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("d"))// || Input.mousePosition.y <=  panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("w"))//|| Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(new Vector3(0,1,1) * panSpeed * Time.deltaTime, Space.Self);//Space.World);new Vector3(0,ry,rz).normalized
        }
        if (Input.GetKey("s"))//|| Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(new Vector3(0,-1,-1) * panSpeed * Time.deltaTime, Space.Self);//new Vector3(0, -ry, -rz).normalized
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(new Vector3(0, 1, 0), Space.World);
        }

    }
}
