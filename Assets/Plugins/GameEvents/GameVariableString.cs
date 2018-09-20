using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameVariable/String", order = (int)MenuOrder.VariableString)]
	public class GameVariableString : BaseGameVariable<GameVariableString, string> {
		protected override string Parse(string stringValue) { return stringValue; }
	}
}