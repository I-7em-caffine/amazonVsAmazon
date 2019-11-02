using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonsAOE : MonoBehaviour
{
    [SerializeField] private AOEUpgrade turret;
    [SerializeField] GameObject damageButton;
    [SerializeField] GameObject radiusButton;
    [SerializeField] GameObject coolDownButton;
    private bool maxDamage = false;
    private bool maxRadius = false;
    private bool maxCoolDown = false;

    public void SetUp(GameObject _turret)
    {
        turret = _turret.GetComponent<AOEUpgrade>();
        if (turret.damageLevel < 5)
            damageButton.GetComponentInChildren<Text>().text = "Damage price: " + turret.damagePrice[turret.damageLevel] + " next damage: " + turret.damagePerLevel[turret.damageLevel];
        if (turret.radiusLevel < 5)
            radiusButton.GetComponentInChildren<Text>().text = "Radius price: " + turret.radiusPrice[turret.radiusLevel] + " next radius: " + turret.radiusPerLevel[turret.radiusLevel];
        if (turret.coolDownLevel < 5)
            coolDownButton.GetComponentInChildren<Text>().text = "Cooldown price: " + turret.coolDownPrice[turret.coolDownLevel] + " next cooldown: " + turret.coolDownPerLevel[turret.coolDownLevel];
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
        if (turret.coolDownLevel == 5)
        {
            maxCoolDown = true;
            coolDownButton.GetComponentInChildren<Text>().text = "Cooldown MAX";
        }

    }
    public void _DamageUpgrade()
    {
        turret.DamageUpgrade();
        if (turret.damageLevel == 5)
        {
            maxDamage = true;
            damageButton.GetComponentInChildren<Text>().text = "Damage MAX";
        }
        if (maxDamage)
            return;
        damageButton.GetComponentInChildren<Text>().text = "Damage price: " + turret.damagePrice[turret.damageLevel] + " next damage: " + turret.damagePerLevel[turret.damageLevel];
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

    public void _CoolDownUpgrade()
    {
        turret.CoolDownUpgrade();
        if (turret.coolDownLevel == 5)
        {
            maxCoolDown = true;
            coolDownButton.GetComponentInChildren<Text>().text = "Firerate MAX";
        }
        if (maxCoolDown)
            return;
        coolDownButton.GetComponentInChildren<Text>().text = "Cooldown price: " + turret.coolDownPrice[turret.coolDownLevel] + " next cooldown: " + turret.coolDownPerLevel[turret.coolDownLevel];
    }

    public void _CloseUI()
    {
        turret.CloseUI();
    }
}
