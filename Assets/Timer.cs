using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text text;
    public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (player.speed != 0)
	    {
            var ts = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);

            text.text = ts.ToString();//.Substring(3, 9);
        }
	}
}
