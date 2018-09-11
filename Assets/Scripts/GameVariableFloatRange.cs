using UnityEngine;
using Utils;

namespace GameVariables {
	[CreateAssetMenu]
	public class GameVariableFloatRange : AbstractGameVariable<float> {
		[SerializeField] private float m_MinValue;
		[SerializeField] private float m_MaxValue = 1;

		protected override bool IsEqual(float a, float b) { return a.Approximately(b); }

		public float Progress {
			get { return (Value - m_MinValue) / (m_MaxValue - m_MinValue); }
			set { Value = Mathf.Clamp(value * (m_MaxValue - m_MinValue) + m_MinValue, m_MinValue, m_MaxValue); }
		}

		protected override void OnValidate() {
			base.OnValidate();
			m_InitialValue = Mathf.Clamp(m_InitialValue, m_MinValue, m_MaxValue);
			Value = Mathf.Clamp(Value, m_MinValue, m_MaxValue);
			m_MinValue = Mathf.Min(m_MinValue, m_MaxValue);
		}
	}
}