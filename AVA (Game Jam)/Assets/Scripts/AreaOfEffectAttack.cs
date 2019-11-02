using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectAttack : MonoBehaviour
{
    [SerializeField] public float attackRadius = 10f;
    [SerializeField] public float damage = 1;
    [SerializeField] public float cooldownTime = 5f;
    private float timer = 5f;
    private List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f)
        {
            Attack();
            timer = cooldownTime;
        }
        timer -= Time.deltaTime;
        gameObject.GetComponent<SphereCollider>().radius = attackRadius;
    }
    void Attack()
    {
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < attackRadius)
            {
                enemy.GetComponent<EnemyHealth>().hitPoints -= damage;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
