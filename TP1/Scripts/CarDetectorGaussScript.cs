using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorGaussScript : CarDetectorScript {

	public float stdDev = 1.0f; 
	public float mean = 0.0f; 
	// Get gaussian output value
	public override float GetOutput()
	{
		//float left = 1f/stdDev*Mathf.Sqrt(2*Mathf.PI);
        //float right = Math.Exp( -1f/2f * (float)Math.Pow(output - mean, 2)/(float)Math.Pow(stdDev, 2));

		return 0f;
	}


}
