﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

	public GameObject applePrefeb;
	public GameObject bombPrefeb;
	float span = 0.5f;
	float delta = 0;
	int ratio = 2;
	float speed = -0.03f;

	public void SetParameter(float span, float speed, int ratio)
	{
		this.span = span;
		this.speed = speed;
		this.ratio = ratio;
	}

	void Start()
	{

	}

	void Update()
	{
		this.delta += Time.deltaTime;
		if (this.delta > this.span)
		{
			GameObject item;
			this.delta = 0;
			int dice = Random.Range(1, 11);
			if (dice <= this.ratio)
			{
				item = Instantiate(bombPrefeb) as GameObject;
			}
			else
			{
				item = Instantiate(applePrefeb) as GameObject;
			}
			float x = Random.Range(-1, 2);
			float z = Random.Range(-1, 2);
			item.transform.position = new Vector3(x, 4, z);
			item.GetComponent<ItemController>().dropSpeed = this.speed;
		}
	}
}
