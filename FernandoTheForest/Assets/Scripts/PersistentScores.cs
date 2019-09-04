using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentScores : MonoBehaviour {

	public float[] scores = new float[4];

	static PersistentScores instance_;
	public static PersistentScores instance
	{
		get
		{
			if (!instance_)
			{
				instance_ = FindObjectOfType<PersistentScores>();
			}
			return instance_;
		}
		private set {
			if (instance_)
			{
				Destroy(instance_);
			}
			instance_ = value;
			DontDestroyOnLoad(value.gameObject);
		}
	}

	private void Awake()
	{
		if (!instance_)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
