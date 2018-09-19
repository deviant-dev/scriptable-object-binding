using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameVariable/Bool", order = 201)]
	public class GameVariableBool : BaseGameVariable<GameVariableBool, bool> {
		protected override bool Parse(string stringValue) { return bool.Parse(stringValue); }
	}
}