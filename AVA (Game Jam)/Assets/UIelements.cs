using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIelements : MonoBehaviour
{
    private GameMaster gm;
    public Text Money;
    public Text Health;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "Money: " + gm.curency;
        Health.text = "Health: " + gm.baseHealth;
        if (gm.baseHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
