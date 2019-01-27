using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : BaseItem {

	protected override void Activate(Player player){
		player.HealthRestore();
	}
}
