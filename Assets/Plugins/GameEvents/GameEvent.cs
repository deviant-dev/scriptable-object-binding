using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameEvent/Generic")]
	public class GameEvent : BaseGameEvent {
		protected override void RaiseDefault() {
			RaiseGeneric();
		}
	}
}