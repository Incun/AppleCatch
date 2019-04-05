using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

	public float dropSpeed = -0.03f;
	public BasketController bc;
	void Start()
	{
		bc = GameObject.Find("basket").GetComponent<BasketController>();
	}

	void Update()
	{
		transform.Translate(0, this.dropSpeed, 0);
		if (transform.position.y < -1.0f)
		{
			if(gameObject.tag == "Apple")
			{
				GameManager.instance.score--;
				GameManager.instance.text.text = "Score : " + GameManager.instance.score.ToString();
			}
			else
			{
				GameManager.instance.score++;
				GameManager.instance.text.text = "Score : " + GameManager.instance.score.ToString();
			}
			Destroy(gameObject);
		}
	}
}
