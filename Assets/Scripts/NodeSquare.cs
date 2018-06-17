using UnityEngine;
using UnityEngine.EventSystems;

public class NodeSquare : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughtMoneyColor;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBluePrint turretBluePrint;

    [HideInInspector]
    public int turretLevel = 0;

    private Renderer rend;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        Vector3 newPos = transform.position;
        newPos.y += 1.25f;
        return newPos;
    }

    void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
            return;
        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab_L01, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = bluePrint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.Money -= bluePrint.cost;
        turretLevel = 1;
    }

    public void UpgradeTurret ()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
            return;

        // get rid of the old turret
        Destroy(turret);

        // Building a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.prefab_L02, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        // Building effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        // Player lost money
        PlayerStats.Money -= turretBluePrint.upgradeCost;
        turretLevel++;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBluePrint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (!buildManager.HasMoney)
            rend.material.color = notEnoughtMoneyColor;
        else
            rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
