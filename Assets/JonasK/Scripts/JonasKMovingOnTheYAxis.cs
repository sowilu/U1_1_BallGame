using System.Collections;
using UnityEngine;

public class JonasKMovingOnTheYAxis : MonoBehaviour
{
	public float frequency = 1;
	public float range = 2;
	Vector3 startPos;

	void Start()
	{
		startPos = transform.position;
	}

	void Update()
	{
		float time = Time.time * frequency;
		transform.position = startPos + Vector3.up * Mathf.Sin(time) * range;
	}
}