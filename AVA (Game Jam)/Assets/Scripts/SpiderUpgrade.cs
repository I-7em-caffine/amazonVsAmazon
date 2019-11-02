using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpiderUpgrade : MonoBehaviour
{
    //Setup
    private SpiderAttack stats;
    private GameMaster gm;

    //UI
    [SerializeField] private GameObject UpgradeMenu;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject rayTrigger;
    private bool isUiOpen = false;

    //Stats per level
    [Header("Slowdown")]
    [SerializeField] public int slowDownLevel = 0;
    [SerializeField] public float[] slowDownPerLevel;
    [SerializeField] public float[] slowDownPrice;
    [Header("Radius")]
    [SerializeField] public int radiusLevel = 0;
    [SerializeField] public float[] radiusPerLevel;
    [SerializeField] public float[] radiusPrice;
    [Header("Cooldown")]
    [SerializeField] public int fireRateLevel = 0;
    [SerializeField] public float[] fireRatePerLevel;
    [SerializeField] public float[] fireRatePrice;

    // Start is called before the first frame update
    void Start()
    {
        stats = gameObject.GetComponent<SpiderAttack>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        System.Random rand = new System.Random();
        int variable = rand.Next(0, 9999);
        rayTrigger.name = "" + variable;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                    UI.GetComponent<SpiderUpgradeButtons>().SetUp(gameObject);
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
    public void SlowDownUpgrade()
    {
        if (slowDownLevel == 5)
            return;
        if (gm.curency >= slowDownPrice[slowDownLevel])
        {
            stats.slowDownPercentage = slowDownPerLevel[slowDownLevel];
            slowDownLevel += 1;
            return;
        }
    }
    public void RadiusUpgrade()
    {
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
        if (fireRatePrice[fireRateLevel] == 0)
            return;
        if (gm.curency >= fireRatePrice[fireRateLevel])
        {
            stats.fireRate = fireRatePerLevel[fireRateLevel];
            fireRateLevel += 1;
            return;
        }
    }
}
