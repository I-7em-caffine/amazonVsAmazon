using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AOEUpgrade : MonoBehaviour
{
    //Setup
    private AreaOfEffectAttack stats;
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
    [Header("Cooldown")]
    [SerializeField] public int coolDownLevel = 0;
    [SerializeField] public float[] coolDownPerLevel;
    [SerializeField] public float[] coolDownPrice;

    // Start is called before the first frame update
    void Start()
    {
        stats = gameObject.GetComponent<AreaOfEffectAttack>();
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
                    UI.GetComponent<UpgradeButtonsAOE>().SetUp(gameObject);
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
        if (radiusLevel == 5)
            return;
        if (gm.curency >= radiusPrice[radiusLevel])
        {
            stats.attackRadius = radiusPerLevel[radiusLevel];
            radiusLevel += 1;
            return;
        }
    }
    public void CoolDownUpgrade()
    {
        if (coolDownPrice[coolDownLevel] == 0)
            return;
        if (gm.curency >= coolDownPrice[coolDownLevel])
        {
            stats.cooldownTime = coolDownPerLevel[coolDownLevel];
            coolDownLevel += 1;
            return;
        }
    }
}
