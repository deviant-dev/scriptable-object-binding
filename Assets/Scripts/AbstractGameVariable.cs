using System;
using UnityEngine;

namespace GameVariables {
	public abstract class BaseGameVariable : ScriptableObject {
		[SerializeField] private string m_DisplayName;
		[SerializeField, Multiline] private string m_Description;

		public string Name { get { return !string.IsNullOrEmpty(m_DisplayName) ? m_DisplayName : name; } }

		public string Description { get { return m_Description; } }

		public abstract string ValueString { get; }
	}

	public abstract class AbstractGameVariable<T> : BaseGameVariable {
		[SerializeField] protected T m_InitialValue;
		[SerializeField] protected T m_CurrentValue;

		private T m_LastValue;
		private string m_ValueString;

		public T Value {
			get { return m_CurrentValue; }
			set {
				if (IsEqual(m_CurrentValue, value)) { return; }
				m_LastValue = m_CurrentValue = value;
				RaiseOnChanged();
			}
		}

		public override string ValueString { get { return Value.ToString(); } }

		protected abstract bool IsEqual(T a, T b);

		public event Action<T> OnChanged;

		protected void OnEnable() { Value = m_InitialValue; }

		protected virtual void OnValidate() {
			if (!Application.isPlaying || IsEqual(m_LastValue, m_CurrentValue)) { return; }
			m_LastValue = m_CurrentValue;
			RaiseOnChanged();
		}

		private void RaiseOnChanged() {
			if (Application.isPlaying && OnChanged != null) { OnChanged(m_CurrentValue); }
		}
	}
}