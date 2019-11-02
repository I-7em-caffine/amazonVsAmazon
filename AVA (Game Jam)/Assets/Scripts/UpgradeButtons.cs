using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    [SerializeField] private TurretUpgrades turret;
    [SerializeField] GameObject damageButton;
    [SerializeField] GameObject radiusButton;
    [SerializeField] GameObject fireRateButton;
    private bool maxDamage = false;
    private bool maxRadius = false;
    private bool maxFireRate = false;

    public void SetUp(GameObject _turret)
    {
        turret = _turret.GetComponent<TurretUpgrades>();
        if (turret.damageLevel < 5)
            damageButton.GetComponentInChildren<Text>().text = "Damage price: " + turret.damagePrice[turret.damageLevel] + " next damage: " + turret.damagePerLevel[turret.damageLevel];
        if (turret.radiusLevel < 5)
            radiusButton.GetComponentInChildren<Text>().text = "Radius price: " + turret.radiusPrice[turret.radiusLevel] + " next radius: " + turret.radiusPerLevel[turret.radiusLevel];
        if (turret.fireRateLevel < 5)
            fireRateButton.GetComponentInChildren<Text>().text = "Firerate price: " + turret.fireRatePrice[turret.fireRateLevel] + " next firerate: " + turret.fireRatePerLevel[turret.fireRateLevel];
    }
    public void Update()
    {
        if (turret.damageLevel == 5)
        {
            maxDamage = true;
            damageButton.GetComponentInChildren<Text>().text = "Damage MAX";
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
    public void _DamageUpgrade()
    {
        Debug.Log("Damage");
        turret.DamageUpgrade();
        if (turret.damageLevel == 5)
        {
            maxDamage = true;
            damageButton.GetComponentInChildren<Text>().text = "Damage MAX";
        }
        if (maxDamage)
            return;
        if (!maxDamage)
            damageButton.GetComponentInChildren<Text>().text = "Damage price: " + turret.damagePrice[turret.damageLevel] + " next damage: " + turret.damagePerLevel[turret.damageLevel];
    }

    public void _RadiusUpgrade()
    {
        Debug.Log("Radius");
        turret.RadiusUpgrade();
        if (turret.radiusLevel == 5)
        {
            maxRadius = true;
            radiusButton.GetComponentInChildren<Text>().text = "Radius MAX";
        }
        if (maxRadius)
            return;
        if(!maxRadius)
            radiusButton.GetComponentInChildren<Text>().text = "Radius price: " + turret.radiusPrice[turret.radiusLevel] + " next radius: " + turret.radiusPerLevel[turret.radiusLevel];
    }

    public void _FireRateUpgrade()
    {
        Debug.Log("fireRate");
        turret.FireRateUpgrade();
        if (turret.fireRateLevel == 5)
        {
            maxFireRate = true;
            fireRateButton.GetComponentInChildren<Text>().text = "Firerate MAX";
            Debug.Log("fireRate max");
        }
        if (maxFireRate)
            return;
        if(!maxFireRate)
            fireRateButton.GetComponentInChildren<Text>().text = "Firerate price: " + turret.fireRatePrice[turret.fireRateLevel] + " next firerate: " + turret.fireRatePerLevel[turret.fireRateLevel];
    }

    public void _CloseUI()
    {
        turret.CloseUI();
    }
}
