using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorGaussScript : LightDetectorScript {

	public float stdDev = 1.0f; 
	public float mean = 0.0f; 
	
	public override float GetOutput()
	{   
        Debug.Log("x = " + output.ToString());
        
        float x = output;
        output = invert_output ? (1-gaussian()) : gaussian();

        if (ApplyThresholds){
            if (x < MinX || x > MaxX){
                output = 0f;
            }
        }

        if (ApplyLimits){
            if (output < MinY)
                output = MinY;
            else if(output>MaxY)
                output = MaxY;
        }

        Debug.Log("y = " + output.ToString());
		return output;
	}

    // Get gaussian output value
    public float gaussian(){
        return (float)Math.Exp( - Math.Pow( output - mean, 2)/(2*Math.Pow(stdDev, 2)));
    }
}
