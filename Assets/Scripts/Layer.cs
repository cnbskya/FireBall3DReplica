using UnityEngine;
using DG.Tweening;

public class Layer : MonoBehaviour
{
	private Vector3 targetPos;
	public int destroyCount = 4;

	private void Start()
	{
		targetPos = transform.position;
		RotateLayer();
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 16);
	}

	public void RotateLayer()
	{
		if (gameObject.CompareTag("Layer") || gameObject.CompareTag("CubeLayer"))
		{
			Sequence run = DOTween.Sequence();
			Tween rot = gameObject.transform.DORotate(new Vector3(0, 2520, 0), 60, RotateMode.FastBeyond360).SetEase(Ease.Linear);
			run.Append(rot).SetLoops(-1);
		}
	}
	public void Fall()
	{
		if (gameObject.CompareTag("Layer"))
		{
			targetPos += Vector3.down * GetComponent<BoxCollider>().bounds.size.y;
		}
		else if (gameObject.CompareTag("Bonus"))
		{
			targetPos += Vector3.down * transform.lossyScale.y; 
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Ball") && (gameObject.CompareTag("Layer") || gameObject.CompareTag("CubeLayer")))
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
			GameManager.instance.TriggerLayer();
		}
		else
		{
			destroyCount--;
			if(destroyCount == 0)
			{
				Destroy(gameObject);
				Destroy(other.gameObject); // Ball Destroy
				GameManager.instance.TriggerLayer();
			}
			Destroy(other.gameObject); // Ball Destroy
		}
	}

}
