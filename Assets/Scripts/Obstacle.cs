using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ball"))
		{
			Destroy(collision.gameObject, 1.2f);
			GameManager.instance.RestartLevel();
			// GAME OVER RESTART LEVEL
		}
	}
}
