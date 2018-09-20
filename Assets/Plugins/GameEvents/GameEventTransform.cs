using UnityEngine;

namespace Deviant.GameEvents {
	[CreateAssetMenu(menuName = "GameEvent/Transform", order = (int)MenuOrder.EventTransform)]
	public class GameEventTransform : BaseGameEvent<GameEventTransform, Transform> { }
}