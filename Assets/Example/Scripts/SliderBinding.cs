using Deviant.GameEvents;
using Deviant.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Bindings {
	public class SliderBinding : MonoBehaviour {
		[SerializeField, FormerlySerializedAs("m_RangeVariable")] private GameVariableFloatRange m_Variable;
		[SerializeField, FormerlySerializedAs("m_SliderControl")] private Slider m_Control;
		[SerializeField] private TextMeshProUGUI m_Label;

		private float m_LastSliderValue;

		private void Start() {
			m_Variable.Changed += OnVariableChanged;
			OnVariableChanged(m_Variable.Progress);
			if (m_Label) { m_Label.text = m_Variable.Name; }
		}

		private void OnVariableChanged(float value) { m_LastSliderValue = m_Control.value = m_Variable.Progress; }

		private void Update() {
			if (!m_LastSliderValue.Approximately(m_Control.value)) { m_LastSliderValue = m_Variable.Progress = m_Control.value; }
		}

		private void OnValidate() {
			if (m_Label && m_Variable) { m_Label.text = m_Variable.Name; }
		}
	}
}