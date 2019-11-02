using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPathScript : MonoBehaviour {
    // Start is called before the first frame update

    public float speed = 1f;
    public int nextWaypoint = 0;
    public int enemyType = 0; // 0 - drone, 1 - truck
    public int damageDoneToBase = 0;
    private GameObject[] waypoints;
    void Start() {
        if(enemyType == 0) {
            waypoints = GameObject.FindWithTag("GameController").GetComponent<GameMaster>().airWaypoints; //gets waypoints from scene variable
        } else if(enemyType == 1) {
            waypoints = GameObject.FindWithTag("GameController").GetComponent<GameMaster>().groundWaypoints;
        } else if(enemyType == 2) {
            waypoints = GameObject.FindWithTag("GameController").GetComponent<GameMaster>().riverWaypoints;
        }

        if (waypoints.Length == 0) {
            waypoints = GameObject.FindGameObjectsWithTag("river_path");
        }

        // goToNextWaypoint();
    }

    // Update is called once per frame
    private float slowdownMultiplier;
    private float slowdownTimer;
    void Update() {
        //workout the direciton and amount the drone should move
        Vector3 targetPosition = waypoints[nextWaypoint].transform.position;
        Vector3 currentPosition = transform.position;
        Vector3 targetDir = targetPosition - currentPosition;
        targetDir.Normalize(); //prevents accelerating and decelerating coming up to waypoints
        if(slowdownTimer > 0) {
            transform.position = transform.position + targetDir * (speed*Time.deltaTime*slowdownMultiplier);
            slowdownTimer -= Time.deltaTime;
        }  else {
            transform.position = transform.position + targetDir * (speed*Time.deltaTime);
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
        if(enemyType == 0) {
            targetRotation *= Quaternion.Euler(-90,0,180);
        } else if(enemyType == 1) {
            targetRotation *= Quaternion.Euler(-90,0,0);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject == waypoints[nextWaypoint]) {
            //the next waypoint has been reached and the waypoint after should be gone
            //to unless this is the last waypoint (the user has FAILED MISSERABLY!!!
            //AND MUST CAPITULATE TO THE WILL OF ALMIGHTY BEZOS)
            if(nextWaypoint == waypoints.Length - 1) {
                enemySuccess();
                Destroy(gameObject);
            } else {
                nextWaypoint++;
                goToNextWaypoint();
            }
        }
    }

    public void slowdown(float slowdown) {
        slowdownTimer = 3f;
        slowdownMultiplier = slowdown;
    }

    void goToNextWaypoint() {

    }

    void enemySuccess() {
        GameObject.FindWithTag("GameController").GetComponent<GameMaster>().baseHealth -= damageDoneToBase;
    }
}
