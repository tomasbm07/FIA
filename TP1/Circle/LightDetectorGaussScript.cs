using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorGaussScript : LightDetectorScript {

	public float stdDev = 1.0f; 
	public float mean = 0.0f; 
	public float min_y;
	public bool inverse = false;
	// Get gaussian output value
	public override float GetOutput()
	{
        float left = 1f/stdDev*Mathf.Sqrt(2*Mathf.PI);
        float right = (float)Math.Exp( - ( Math.Pow(output - mean, 2) / (2*Math.Pow(stdDev, 2) ) ) );

        if (inverse)
            return 1/(left*right);
		return left * right;
	}


}
