using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	public override float GetOutput()
	{   
        Debug.Log("x = " + output.ToString());

        float x = output;
        if (invert_output){
                output = 1f - output;
        }  

        if (ApplyThresholds){
            if (x < MinX || x > MaxX)
                output=0f;
        } 

        if (ApplyLimits){
            if (output < MinY)
                output = MinY;
            else if(output > MaxY)
                output = MaxY;
        }    

        Debug.Log("y = " + output.ToString());
		return output;
	}

	// YOUR CODE HERE


}
