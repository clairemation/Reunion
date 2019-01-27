using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : BaseItem {

	protected override void Activate(Player player){
		EventManager.TriggerEvent(EventNames.SCORE_INCREASED);
	}
}
