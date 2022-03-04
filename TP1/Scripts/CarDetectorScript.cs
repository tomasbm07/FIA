using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {

	public float car_angle = 180f;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public float output;
	public int numObjects;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (car_angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()
	{
		// YOUR CODE HERE

		GameObject[] cars = GetVisibleCars();
		GameObject closestCar = null;

		if (cars.Length == 0)
            output = 0;
        else{
            output = 999999;
            float temp, temp_ang;
            foreach(GameObject car in cars){
                temp = Vector3.Distance(transform.position, car.transform.position) * 0.05f;
                if (temp < output) output = temp;
            }
        }

	}

	public virtual float GetOutput() { throw new NotImplementedException(); }

	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// YOUR CODE HERE
    GameObject[] GetVisibleCars()
	{
		ArrayList visibleCars = new ArrayList();
		float halfAngle = car_angle / 2.0f;

		GameObject[] cars = GameObject.FindGameObjectsWithTag ("CarToFollow");

		foreach (GameObject car in cars) {
			Vector3 toVector = (car.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
            
			float angleToTarget = Vector3.Angle (forward, toVector);
            Debug.Log(gameObject.name + " : " + angleToTarget + " < " + halfAngle);
			if (angleToTarget <= halfAngle) {
				visibleCars.Add (car);
			}
		}

		return (GameObject[])visibleCars.ToArray(typeof(GameObject));
	}

}
