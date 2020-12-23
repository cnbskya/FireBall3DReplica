using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
	public GameObject player;
	public bool isMove;
	public bool isLeft;

	public void MovePlayer()
	{
		transform.DOMoveZ(0, 1).SetEase(Ease.Linear).OnComplete(() => {
			transform.DORotate(new Vector3(0, -45, 0), 1f).OnComplete(() => {
				transform.DOMove(new Vector3(-3.75f, 0, 3.75f), 1);
			});
		});
	}
}
