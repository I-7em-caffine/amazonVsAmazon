using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderUpgradeButtons : MonoBehaviour
{
    [SerializeField] private SpiderUpgrade turret;
    [SerializeField] GameObject slowDownButton;
    [SerializeField] GameObject radiusButton;
    [SerializeField] GameObject fireRateButton;
    private bool maxSlowDown = false;
    private bool maxRadius = false;
    private bool maxFireRate = false;

    public void SetUp(GameObject _turret)
    {
        turret = _turret.GetComponent<SpiderUpgrade>();
        if (turret.slowDownLevel < 5)
            slowDownButton.GetComponentInChildren<Text>().text = "Slowdown price: " + turret.slowDownPrice[turret.slowDownLevel] + " next Slowdown: " + turret.slowDownPerLevel[turret.slowDownLevel];
        if (turret.radiusLevel < 5)
            radiusButton.GetComponentInChildren<Text>().text = "Radius price: " + turret.radiusPrice[turret.radiusLevel] + " next radius: " + turret.radiusPerLevel[turret.radiusLevel];
        if (turret.fireRateLevel < 5)
            fireRateButton.GetComponentInChildren<Text>().text = "Firerate price: " + turret.fireRatePrice[turret.fireRateLevel] + " next firerate: " + turret.fireRatePerLevel[turret.fireRateLevel];
    }
    public void Update()
    {
        if (turret.slowDownLevel == 5)
        {
            maxSlowDown = true;
            slowDownButton.GetComponentInChildren<Text>().text = "Slowdown MAX";
        }
        if (turret.radiusLevel == 5)
        {
            maxRadius = true;
            radiusButton.GetComponentInChildren<Text>().text = "Radius MAX";
        }
        if (turret.fireRateLevel == 5)
        {
            maxFireRate = true;
            fireRateButton.GetComponentInChildren<Text>().text = "Firerate MAX";
        }

    }
    public void _SlowDownUpgrade()
    {
        turret.SlowDownUpgrade();
        if (turret.slowDownLevel == 5)
        {
            maxSlowDown = true;
            slowDownButton.GetComponentInChildren<Text>().text = "Slowdown MAX";
        }
        if (maxSlowDown)
            return;
        slowDownButton.GetComponentInChildren<Text>().text = "Slowdown price: " + turret.slowDownPrice[turret.slowDownLevel] + " next Slowdown: " + turret.slowDownPerLevel[turret.slowDownLevel];
    }

        public void _RadiusUpgrade()
    {
        turret.RadiusUpgrade();
        if (turret.radiusLevel == 5)
        {
            maxRadius = true;
            radiusButton.GetComponentInChildren<Text>().text = "Radius MAX";
        }
        if (maxRadius)
            return;
        radiusButton.GetComponentInChildren<Text>().text = "Radius price: " + turret.radiusPrice[turret.radiusLevel] + " next radius: " + turret.radiusPerLevel[turret.radiusLevel];
    }

    public void _FireRateUpgrade()
    {
        turret.FireRateUpgrade();
        if (turret.fireRateLevel == 5)
        {
            maxFireRate = true;
            fireRateButton.GetComponentInChildren<Text>().text = "Firerate MAX";
        }
        if (maxFireRate)
            return;
        fireRateButton.GetComponentInChildren<Text>().text = "Firerate price: " + turret.fireRatePrice[turret.fireRateLevel] + " next firerate: " + turret.fireRatePerLevel[turret.fireRateLevel];
    }

    public void _CloseUI()
    {
        turret.CloseUI();
    }
}
