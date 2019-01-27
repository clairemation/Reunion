using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : BaseItem {

	protected override void Activate(Player player){
		player.ShieldActivated();
	}
}
