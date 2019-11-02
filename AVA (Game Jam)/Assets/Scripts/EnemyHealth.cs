using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float hitPoints = 1f;
    private float initialHitPoints;
    // Start is called before the first frame update
    void Start()
    {
        initialHitPoints = hitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            GameObject.FindWithTag("GameController").GetComponent<GameMaster>().curency += 0.2f * initialHitPoints;
            return;     
        }
    }
}
