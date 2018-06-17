using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint MachineGunTurret;
    public TurretBluePrint MissileTurret;
    public TurretBluePrint SniperTurret;
    public TurretBluePrint LaserBeamerTurret;

    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectMachineGunTurret()
    {
        buildManager.SelectTurretToBuild(MachineGunTurret);
    }

    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(MissileTurret);
    }

    public void SelectSniperTurret()
    {
        buildManager.SelectTurretToBuild(SniperTurret);
    }

    public void SelectLaserBeamerTurret()
    {
        buildManager.SelectTurretToBuild(LaserBeamerTurret);
    }
}
