
using UnityEngine;

public class Shop : MonoBehaviour { //Return which kind of turret to build

    BuildManager buildManager;

    public TurretBluePoint Acid;
    public TurretBluePoint Laser;
    public TurretBluePoint Cannon;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectAcidTurret()
    {
        //Debug.Log("Acid Selected");
        buildManager.SelectTurretToBuild(Acid);
    }
    public void SelectLaserTurret()
    {
        //Debug.Log("Laser Selected");
        buildManager.SelectTurretToBuild(Laser);
    }
    public void SelectCannonTurret()
    {
        //Debug.Log("Cannon Selected");
        buildManager.SelectTurretToBuild(Cannon);
    }
    }
