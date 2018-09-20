using Deviant.GameEvents;
using Deviant.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bindings {
	public class SliderBinding : MonoBehaviour {
		[SerializeField] private GameVariableFloatRange m_RangeVariable;
		[SerializeField] private Slider m_SliderControl;
		[SerializeField] private TextMeshProUGUI m_Label;

		private float m_LastSliderValue;

		private void Start() {
			m_RangeVariable.Changed += OnVariableChanged;
			m_LastSliderValue = m_SliderControl.value = m_RangeVariable.Progress;
			if (m_Label) { m_Label.text = m_RangeVariable.Name; }
		}

		private void OnVariableChanged(float value) { m_SliderControl.value = m_RangeVariable.Progress; }

		private void Update() {
			if (!m_LastSliderValue.Approximately(m_SliderControl.value)) { m_LastSliderValue = m_RangeVariable.Progress = m_SliderControl.value; }
		}

		private void OnValidate() {
			if (m_Label && m_RangeVariable) { m_Label.text = m_RangeVariable.Name; }
		}
	}
}