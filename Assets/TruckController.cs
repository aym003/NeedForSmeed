using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
private CharacterController controller;
private float verticalVelocity;
private float speed = 7.0f;
private float LANE_DISTANCE = 3.0f;
private int desiredLane = 1;
[SerializeField] private GameObject _smeed; 
    // Start is called before the first frame update
    void Start()
    {
     controller = GetComponent<CharacterController>();	   
    }

    // Update is called once per frame
    void Update()
    {
        var rnd = Random.Range(0, 2);
        int direction = rnd;
        if (direction == 0)
            MoveLane(false);
        if (direction == 1)
            MoveLane(true);


        Vector3 targetPosition = transform.position.z * Vector3.forward;
        targetPosition.y = 0.0f;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }
        else if (desiredLane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = 0.0f;
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);
        var boolSmeed = Random.Range(0, 1);
        int boolSm = boolSmeed;
        double result = new System.Random().Next(0,100);
        System.Console.Write(result);
        Vector3 test = targetPosition;
        if (result == 1) {
            
        if (boolSm == 2)

            test.y = 0.1f;
        SpawnSmeedAtPosition(test);
    }
	}
	private void MoveLane(bool goingRight){
		desiredLane += (goingRight) ? 1 : -1;
		desiredLane = Mathf.Clamp(desiredLane,0,2);
	}
	private void SpawnSmeedAtPosition(Vector3 spawnPosition){
	GameObject smeed = Instantiate(_smeed, spawnPosition, Quaternion.identity);
        smeed.transform.localScale= Vector3.Scale(transform.localScale, new Vector3(10, 10, 10));

    }
}
