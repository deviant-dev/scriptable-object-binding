using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameEvent/String", order = (int)MenuOrder.EventString)]
	public class GameEventString : BaseGameEvent<GameEventString, string> { }
}