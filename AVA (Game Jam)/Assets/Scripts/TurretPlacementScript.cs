using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacementScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] turrets;
    private GameObject currentPlannedTurret;
    
    private int selectedTurretIndex = -1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkKeyPress();

        if(selectedTurretIndex != -1) {
            if(Input.GetMouseButtonDown(0) && currentPlannedTurret.GetComponent<ThingThatMakesPlacementWorkIDKWhy>().price < GameObject.FindWithTag("GameController").GetComponent<GameMaster>().curency) {
                currentPlannedTurret.GetComponent<Turrets>().canFire = true;
                currentPlannedTurret = null;
                GameObject.FindWithTag("GameController").GetComponent<GameMaster>().curency = GameObject.FindWithTag("GameController").GetComponent<GameMaster>().curency - currentPlannedTurret.GetComponent<ThingThatMakesPlacementWorkIDKWhy>().price;
            }
            drawPlannedTurret();
        } else if(currentPlannedTurret != null) {
            Destroy(currentPlannedTurret);
        }

    }

    void drawPlannedTurret() {

        //find out where on the map the user is pointing
        Ray mousePointRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //what did it hit?
        RaycastHit hitInfo;
        if(Physics.Raycast(mousePointRay, out hitInfo)) {
            if(currentPlannedTurret == null) {
                currentPlannedTurret = Instantiate(turrets[selectedTurretIndex]);
                currentPlannedTurret.GetComponent<Turrets>().canFire = false;
            }
            if(hitInfo.collider.tag == "ground") {
                float yOffset = 0f;
                if(currentPlannedTurret.GetComponent<ThingThatMakesPlacementWorkIDKWhy>().turretName == "monkey") { yOffset = 1f; }
                else if(currentPlannedTurret.GetComponent<ThingThatMakesPlacementWorkIDKWhy>().turretName == "tree") { yOffset = 0.8f; }
                else if(currentPlannedTurret.GetComponent<ThingThatMakesPlacementWorkIDKWhy>().turretName == "eel") {yOffset=0.1f;}
                else if(currentPlannedTurret.GetComponent<ThingThatMakesPlacementWorkIDKWhy>().turretName == "spider") {yOffset=0.5f;}
                else if(currentPlannedTurret.GetComponent<ThingThatMakesPlacementWorkIDKWhy>().turretName == "frogs") {yOffset=0.2f;}

                currentPlannedTurret.transform.position = hitInfo.point;
                currentPlannedTurret.transform.position = new Vector3(currentPlannedTurret.transform.position.x, currentPlannedTurret.transform.position.y + 1f, currentPlannedTurret.transform.position.z);
                currentPlannedTurret.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            }
        }
    } 

    void checkKeyPress() {
        if(Input.GetKeyDown("1")) {
            if(selectedTurretIndex == 0) { selectedTurretIndex = -1; }
            else { selectedTurretIndex = 0; }
            Destroy(currentPlannedTurret);
        } else if(Input.GetKeyDown("2")) {
            if(selectedTurretIndex == 1) { selectedTurretIndex = -1; }
            else { selectedTurretIndex = 1; }
            Destroy(currentPlannedTurret);
        } else if(Input.GetKeyDown("3")) {
            if(selectedTurretIndex == 2) { selectedTurretIndex = -1; }
            else { selectedTurretIndex = 2; }
            Destroy(currentPlannedTurret);
        } else if(Input.GetKeyDown("4")) {
            if(selectedTurretIndex == 3) { selectedTurretIndex = -1; }
            else { selectedTurretIndex = 3; }
            Destroy(currentPlannedTurret);
        } else if(Input.GetKeyDown("5")) {
            if(selectedTurretIndex == 4) { selectedTurretIndex = -1; }
            else { selectedTurretIndex = 4; }
            Destroy(currentPlannedTurret);
        }
    }
}
