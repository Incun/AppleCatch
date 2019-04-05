using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
	public AudioClip appleSE;
	public AudioClip bombSE;
	AudioSource aud;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Apple")
		{
			this.aud.PlayOneShot(this.appleSE);
			GameManager.instance.score++;
			GameManager.instance.text.text = "Score : " + GameManager.instance.score.ToString();
		}
		else
		{
			GameManager.instance.isGameOver = true;
			this.aud.PlayOneShot(this.bombSE);
			GameManager.instance.text.text = " ";
			Time.timeScale = 0;
			GameManager.instance.gameOverScore.text = "Score : " + GameManager.instance.score.ToString();
			GameManager.instance.gameOverPanel.SetActive(true);
			
		}
		Destroy(other.gameObject);
		
	}

	void Start()
	{
		GameManager.instance.score = 0;
		GameManager.instance.text.text = "Score : " + GameManager.instance.score.ToString();
		this.aud = GetComponent<AudioSource>();
	}

	void Update()
	{
		
		if (Input.GetMouseButtonDown(0) && GameManager.instance.isGameOver == false)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				float x = Mathf.RoundToInt(hit.point.x);
				float z = Mathf.RoundToInt(hit.point.z);
				transform.position = new Vector3(x, 0.0f, z);
			}
		}
	}
}
