using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBuyControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.GetAxis("LClick"));
        print(Input.GetAxis("Mouse X"));
        print(Input.GetAxis("Mouse Y"));
    }

    void create()
    {
        tower();
    }

    void tower()
    {

    }
}
