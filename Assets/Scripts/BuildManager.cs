
using UnityEngine;

public class BuildManager : MonoBehaviour { // This class is used to control building turrets on nodes.

    public static BuildManager instance;// make sure all Nodes could access this buildmanager 确定所有Node都能使用这个


     void Awake() // make sure every node has this attribute
    {
        
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager");
        }
        instance = this;
    }


    public GameObject buildEffect; // Building effect


    private TurretBluePoint turretToBuild; // Turret to build
    private Node selectedNode; // selected node

    public NodeUI nodeUI; // UI for upgrade and sell


    public bool CanBuild { get { return turretToBuild != null; } }//Only readable 只容许读取 不能设置 
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } } // Whether has money for building or upgrading




    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            Debug.Log("DeselectNode");
            DeselectNode();
            return;
        }
        selectedNode = node; // select current node
        turretToBuild = null; // 
        Debug.Log("SetTarget");
        nodeUI.SetTarget(node);

    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBluePoint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePoint GetTurretToBuild()
    {
        return turretToBuild;
    }


}
