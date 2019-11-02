using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebBullet : MonoBehaviour
{
    public float slowDown = 0f;
    private Transform target;

    public float speed = 70f;
    // Start is called before the first frame update
    public void Seek(Transform _target, float _slowDown)
    {
        target = _target;
        slowDown = _slowDown;
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
        if(target.gameObject.GetComponent<followPathScript>() != null)
            target.gameObject.GetComponent<followPathScript>().slowdown(slowDown);
        Destroy(gameObject);
    }
}
