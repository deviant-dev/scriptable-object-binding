using System;
using UnityEngine;

namespace Deviant.GameEvents {
	public abstract class BaseGameVariable : BaseGameEvent {
		public abstract string ValueString { get; set; }
	}

	public abstract class BaseGameVariable<thisT, T> : BaseGameVariable where thisT : BaseGameVariable<thisT, T> {
		[SerializeField] protected T m_InitialValue;

		public event Action<T> Changed;

		[NonSerialized] private T m_CurrentValue;
		[NonSerialized] private T m_LastValue;

		public T Value {
			get { return m_CurrentValue; } 
			set {
				if (Equals(m_CurrentValue, value)) { return; }
				SetValue(value);
				Raise();
			}
		}

		protected virtual void SetValue(T value) { m_CurrentValue = value; }

		public override string ValueString {
			get { return m_CurrentValue == null ? "--null--" : m_CurrentValue.ToString(); }
			set { Value = Parse(value); }
		}

		protected abstract T Parse(string value);

		protected virtual bool Equals(T a, T b) { return object.Equals(a, b); }

		protected override void Init() {
			base.Init();
			Changed = null;
			m_LastValue = m_CurrentValue = m_InitialValue;
		}

		protected override void RaiseDefault() {
			DataInfo = string.Format("({0})", ValueString);

			RaiseGeneric();

			if (Changed != null) {
				try { Changed(Value); }
				catch (Exception e) { Debug.LogException(e); }
			}
		}

		protected virtual void OnValidate() {
			if (Equals(m_CurrentValue, m_LastValue)) { return; }
			m_LastValue = m_CurrentValue;
			if (Application.isPlaying) { Raise(); }
		}
	}
}