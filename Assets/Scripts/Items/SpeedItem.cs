using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : BaseItem {

	[SerializeField] float time = 10f;
	[SerializeField] float speedMultiplier = 1.5f;

	protected override void Activate(Player player){
		player.TimedSpeedIncrease(time, speedMultiplier);
	}
}
