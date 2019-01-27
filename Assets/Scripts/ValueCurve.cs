using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ValueCurve {

	[Serializable]
	public enum CurveType {
		Linear
	}

	[SerializeField] float minVal;
	[SerializeField] float maxVal;
	[SerializeField] CurveType curveType = CurveType.Linear;

	public float GetValue (float x) {
		bool reversed = (maxVal < minVal);

		float result = -1f;
		switch(curveType){
			case CurveType.Linear:
				result = reversed ? 
							Mathf.InverseLerp(maxVal, minVal, x) :
							Mathf.InverseLerp(minVal, maxVal, x);
				break;
			default:
				break;
		}
		return result;
	}

	public int GetIntValue(float x){
		return Mathf.RoundToInt(GetValue(x));
	}
}
