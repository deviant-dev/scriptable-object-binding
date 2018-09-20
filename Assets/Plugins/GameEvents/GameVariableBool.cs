using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameVariable/Bool", order = (int)MenuOrder.VariableBool)]
	public class GameVariableBool : BaseGameVariable<GameVariableBool, bool> {
		protected override bool Parse(string stringValue) { return bool.Parse(stringValue); }
	}
}