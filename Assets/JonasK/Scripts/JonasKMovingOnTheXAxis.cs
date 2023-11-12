using System.Collections;
using UnityEngine;

public class JonasKMovingOnTheXAxis : MonoBehaviour
{
	public float frequency = 1;
	public float range = 2;
	public float initialTimeOffset = 0;
	Vector3 startPos;

	void Start()
	{
		startPos = transform.position;
	}

	void Update()
	{
		float time = (Time.time - initialTimeOffset) * frequency;
		transform.position = startPos + Vector3.left * Mathf.Cos(time) * range;
	}
}