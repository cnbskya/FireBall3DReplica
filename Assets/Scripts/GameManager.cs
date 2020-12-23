using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public Transform level, player;
	public GameObject obstacle;
	public List<Transform> levels;

	public GameObject completeLevelPanel;
	void Start()
	{
		instance = this;
		level = levels[0];
	}

	public void TriggerLayer()
	{
		if(level.childCount > 1)
		{			
			foreach (Transform layer in level)
			{
				layer.GetComponent<Layer>().Fall();
			}
		}
		
		else if (level.childCount == 1){
			Transform layer = level.GetChild(0);
			layer.GetComponent<Layer>().Fall();
			FindObjectOfType<PivotMovement>().isRotate = false;

			if(levels.Count > 1)
			{
				obstacle.transform.DOMoveY(-1.05f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
				{ // Engeller kayboluyor. 
					obstacle.transform.position = new Vector3(-10, 0, 10); // Engellerin yeri ayarlanıyor.
					obstacle.GetComponent<PivotMovement>().isRotate = true; // Engeller dönmeye devam ediyor.
				});
			}
			ChangeLevel();
		}
	}

	public void ChangeLevel()
	{
		if(levels.Count > 1)
		{
			levels.Remove(level);
			level = levels[0];
			FindObjectOfType<PlayerMovement>().MovePlayer();
		}
		else
		{
			obstacle.transform.DOMoveY(-1.05f, 0.5f).SetEase(Ease.Linear);
			LevelComplete();
		}
	}

	public void LevelComplete()
	{
		completeLevelPanel.SetActive(true);
	}
	public void NextLevel()
	{
		SceneManager.LoadScene("SampleScene");
	}
	public void RestartLevel()
	{
		SceneManager.LoadScene("SampleScene");
	}
}
