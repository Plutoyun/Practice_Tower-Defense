using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour { //Upgrade and Sell

    public GameObject UI;
    //public Transform Camera;

    private Node target;

    public Text upgradeCost;
    public Button upgradeButton;
    public Vector3 correctDir = new Vector3(0, 2, 0); // Correct building position

    public Text sellAmout;

    private void Update()
    {
       // LookAtCamera();
    }

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition() + correctDir;
       // Debug.Log(target.UpgradeLevel);   
        if (target.UpgradeLevel == 1)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost_1;
            upgradeButton.interactable = true;
        }
        if (target.UpgradeLevel ==2)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost_2;
            upgradeButton.interactable = true;
        }
        if (target.UpgradeLevel == 3 )
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmout.text = "$" + target.turretBlueprint.GetSellAmount();

        UI.SetActive(true);
    }

    public void Hide()
    {
       UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

   /* void LookAtCamera()
    {
        Vector3 dir = Camera.position - transform.position;//角度目标向量 B-A
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime *10).eulerAngles;//lerp用来平滑移动
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);//只绕着Y轴
    }*/
}
