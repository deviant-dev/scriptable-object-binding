using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameVariable/Int", order = (int)MenuOrder.VariableInt)]
	public class GameVariableInt : BaseGameVariable<GameVariableInt, int> {
		protected override int Parse(string stringValue) { return int.Parse(stringValue); }
	}
}