using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgrades : MonoBehaviour
{
    //Setup
    private Turrets stats;
    private float baseDamage;
    private float baseRadius;
    private float baseFireRate;
    private GameMaster gm;

    //UI
    [SerializeField] private GameObject UpgradeMenu;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject rayTrigger;
    private bool isUiOpen = false;
    
    //Stats per level
    [Header("Damage")]
    [SerializeField] public int damageLevel = 0;
    [SerializeField] public float[] damagePerLevel;
    [SerializeField] public float[] damagePrice;
    [Header("Radius")]
    [SerializeField] public int radiusLevel = 0;
    [SerializeField] public float[] radiusPerLevel;
    [SerializeField] public float[] radiusPrice;
    [Header("Fire Rate")]
    [SerializeField] public int fireRateLevel = 0;
    [SerializeField] public float[] fireRatePerLevel;
    [SerializeField] public float[] fireRatePrice;

    // Start is called before the first frame update
    void Start()
    {
        stats = gameObject.GetComponent<Turrets>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        System.Random rand = new System.Random();
        int variable = rand.Next(0, 9999);
        rayTrigger.name = "" + variable;
            
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.position == rayTrigger.transform.position)
                {
                    if (isUiOpen)
                    {
                        CloseUI();
                        return;
                    }
                    UI = (GameObject)Instantiate(UpgradeMenu);
                    UI.GetComponent<UpgradeButtons>().SetUp(gameObject);
                    isUiOpen = true;
                }
            }
        }
    }
    public void CloseUI()
    {
        Destroy(UI);
        isUiOpen = false;
        UI = null;
    }
    public void DamageUpgrade()
    {
        Debug.Log("damage execute");
        if (damageLevel == 5)
            return;
        if (gm.curency >= damagePrice[damageLevel])
        {

            stats.damage = damagePerLevel[damageLevel];
            damageLevel += 1;
            return;
        }
    }
    public void RadiusUpgrade()
    {
        Debug.Log("radius execute");
        if (radiusLevel == 5)
            return;
        if (gm.curency >= radiusPrice[radiusLevel])
        {
            
            stats.attackRadius = radiusPerLevel[radiusLevel];
            radiusLevel += 1;
            return;
        }
    }
    public void FireRateUpgrade()
    {
        Debug.Log("fireRate execute");
        if (fireRateLevel == 5)
            return;
        if (gm.curency >= fireRatePrice[fireRateLevel])
        {

            stats.fireRate = fireRatePerLevel[fireRateLevel];
            fireRateLevel += 1;
            return;
        }
    }
}
