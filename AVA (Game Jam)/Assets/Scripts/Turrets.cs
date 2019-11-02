using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{

    [SerializeField] public float damage = 1f;
    [SerializeField] public float fireRate = 1f;
    private float fireCountDown = 0f;
    [SerializeField] public float attackRadius = 10f;
    
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private AudioSource sound;

    [SerializeField] private bool doesRotate;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private float rotationSpeed = 1f;

    private Transform target = null;

    private List<GameObject> enemies = new List<GameObject>();

    // public string turretType;
    public bool canFire = true;
    // public float price;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            enemies.Add(other.gameObject);
        } 
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                enemies.Remove(enemy);
                return;
            } 
            else if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }
        }
        if (closestEnemy != null && shortestDistance <= attackRadius)
        {
            target = closestEnemy.transform;
        }
        else
            target = null;

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SphereCollider>().radius = attackRadius;
        if (target == null)
            return;
        if (fireCountDown <= 0f)
        {
            if(canFire) {
                Shoot();
            }
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;

        if (doesRotate)
        {
            Vector3 targetDir = target.position - rotationPoint.position;
            float step = rotationSpeed * Time.deltaTime;
            targetDir.y = 0;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            
        }
       
    }
    void Shoot()
    {
        GameObject startBullet = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet bulletScript = startBullet.GetComponent<Bullet>();
        sound.Play();
        
        if (bulletScript != null)
            bulletScript.Seek(target, damage);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
