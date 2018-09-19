using Deviant.GameEvents;
using TMPro;
using UnityEngine;

namespace Bindings {
	public class ValueTextBinding : MonoBehaviour {
		[SerializeField] private GameVariableFloatRange m_RangeVariable;
		[SerializeField] private TextMeshProUGUI m_Label;

		private void Start() {
			m_RangeVariable.Changed += OnVariableChanged;
			m_Label.text = m_RangeVariable.ValueString;
		}

		private void OnVariableChanged(float value) { m_Label.text = m_RangeVariable.ValueString; }

		private void OnValidate() {
			if (m_Label && m_RangeVariable) { m_Label.text = m_RangeVariable.ValueString; }
		}
	}
}