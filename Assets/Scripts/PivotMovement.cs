using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement : MonoBehaviour
{
	public bool isRotate;

	void Update()
	{
		if(isRotate == true)
		{
			transform.Rotate(new Vector3(0, 80 * Time.deltaTime, 0));
		}
		else
		{
			transform.Rotate(new Vector3(0, 0, 0));
		}
	}
}
