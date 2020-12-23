using System;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
	public Transform ball,playerFire,player;
	private Transform clone;
	

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			clone = Instantiate(ball, playerFire.position, playerFire.rotation);
			clone.GetComponent<Rigidbody>().velocity = playerFire.forward * 20;
		}
	}
}