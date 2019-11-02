using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    private Transform target;

    public float speed = 70f;
    // Start is called before the first frame update
    public void Seek(Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
    private void HitTarget()
    {
        target.gameObject.GetComponent<EnemyHealth>().hitPoints -= damage;
        Destroy(gameObject);
    }
}
