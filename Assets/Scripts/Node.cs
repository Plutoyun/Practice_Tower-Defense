using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour { // Node Component


    public Color hoverColor;
    public Vector3 positionOffset; // Modify the position to place the turrent on the surface of node
    public Color AlarmColor; // Alarm when player doesn't have enough money

    [Header("optional")]
    public GameObject turret; // Turrent built
    [HideInInspector] // Not display this attribute in window
    public TurretBluePoint turretBlueprint; // Turrent's kind
    [HideInInspector]
    public int UpgradeLevel = 1;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color; //Default color 
        UpgradeLevel = 1;
        buildManager = BuildManager.instance; // Get build manager
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset; 
    }

    void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        {
            
            buildManager.SelectNode(this); // Select node
            return;
        }

         if (!buildManager.CanBuild) //If cannot build (has a turrent built)
        {
            return;
        }


        BuildTurret(buildManager.GetTurretToBuild()); //build
    }

    void BuildTurret(TurretBluePoint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost) // If has enough money
        {
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity); //Build turret
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //Build effect
        Destroy(effect, 5f);
       // Debug.Log("Turret build! " );
    }

    public void UpgradeTurret()
    {
        if (UpgradeLevel == 1)
        {

        if (PlayerStats.Money < turretBlueprint.upgradeCost_1)
        {
            Debug.Log("Not Enough Money to Upgrade Level 1");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost_1;

        //get rid of the old turret 
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab_1, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        //isUpgraded = true;
        Debug.Log("First Level Turret Upgrated! ");
        UpgradeLevel = 2;
            return;
        }

        if (UpgradeLevel == 2)
        {

            if (PlayerStats.Money < turretBlueprint.upgradeCost_2)
            {
                Debug.Log("Not Enough Money to Upgrade Level 2");
                return;
            }

            PlayerStats.Money -= turretBlueprint.upgradeCost_2;

            //get rid of the old turret 
            Destroy(turret);

            //Build a new one
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab_2, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            //isUpgraded = true;
            Debug.Log("Second Level Turret Upgrated! ");
            UpgradeLevel = 3;
            return;
        }
    }
    
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        turretBlueprint = null;
       UpgradeLevel = 1;
    }


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())//判断UI是否覆盖在物体之上。以保证不触动UI下看不见的物体上的事件 
            //whether the UI is overlaid on the object. To ensure that events on invisible objects under the UI are not touched
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            GetComponent<Renderer>().material.color = hoverColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = AlarmColor; 
        }
       
    }

     void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
