using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject Nature_TreeTower = null;
    [SerializeField] private GameObject Nature_Eels = null;
    [SerializeField] private GameObject Nature_Monkey = null;
    [SerializeField] private GameObject Nature_SpiderTower = null;
    [SerializeField] public Vector3 pos;
    [SerializeField] private Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Build" + Input.GetAxisRaw("LClick"));
        
        transform.position = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        
        
        if (Input.GetMouseButtonDown(0))
        {
           //Place();
        }

    }

    private void FixedUpdate()
    {
        
    }

    void EelPlace()
    {

    }

    public void TreePlace()
    {
        temp = transform.position;
        temp.z = temp.y;
        transform.position = temp;

        pos = transform.position;
        pos.y = 15;
        transform.position = pos;
        
        GameObject tower = (GameObject)Instantiate(Nature_TreeTower, transform.position, transform.rotation); ;
    }

    void MonkeyPlace()
    {

    }

    public void SpiderPlace()
    {
        
    }
}
