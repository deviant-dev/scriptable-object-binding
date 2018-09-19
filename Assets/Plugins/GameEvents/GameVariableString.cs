using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameVariable/String", order = 205)]
	public class GameVariableString : BaseGameVariable<GameVariableString, string> {
		protected override string Parse(string stringValue) { return stringValue; }
	}
}