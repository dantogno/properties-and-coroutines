using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    Player player;
	
	// Update is called once per frame
	void Update () 
	{
        // Slider value must be between 0 and 1.
        slider.value = player.CurrentHitpointsAsPercentage;
	}
}
