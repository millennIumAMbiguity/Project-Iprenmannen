using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public TMPro.TextMeshProUGUI timeScore;
	public TMPro.TextMeshProUGUI killScore;

	private void Start()
	{
		timeScore.text = ((int)Stats.instance.time) + " Seconds";
		killScore.text = Stats.instance.kills.ToString();
	}
}
