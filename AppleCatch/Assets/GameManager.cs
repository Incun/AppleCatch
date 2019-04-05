using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public float score;
	public Text text;
	public Text gameOverScore;
	public GameObject gameOverPanel;
	public bool isGameOver = false;
	private void Awake()
	{
		isGameOver = false;
		if (instance)
		{
			Destroy(instance);
		}
		instance = this;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void Update()
	{
		if(score<=0)
		{
			GameManager.instance.score = 0;
			GameManager.instance.text.text = "Score : " + GameManager.instance.score.ToString();
		}
	}
}
