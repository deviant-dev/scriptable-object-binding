using Deviant.Utils;
using UnityEditor;
using UnityEngine;

namespace Deviant.GameEvents {
	[CustomEditor(typeof(BaseGameEvent), true)]
	public class BaseGameEventEditor : Editor {
		private BaseGameEvent m_Target;

		private BaseGameEvent Target {
			get { return m_Target ? m_Target : (m_Target = (BaseGameEvent) target); }
		}

		private void OnEnable() {
			if (Application.isPlaying) {
				Target.GenericEvent += OnEvent;
			}
		}

		private void OnDisable() {
			if (Application.isPlaying) {
				Target.GenericEvent -= OnEvent;
			}
		}

		private void OnEvent() { Repaint(); }

		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			if (Application.isPlaying) {
				using (new EditorGUI.DisabledGroupScope(!Application.isPlaying || targets.Length != 1)) {
					EditorUtils.OptionalUnserializedPropertyFieldGUILayout(target, "Value", "Current Value");
				}
			}

			using (new EditorGUI.DisabledGroupScope(!Application.isPlaying)) {
				if (GUILayout.Button("Raise")) {
					Target.Raise();
				}
			}
		}
	}
}