using System;
using UnityEngine;

namespace GameVariables {
    [CreateAssetMenu]
    public class GameVariableFloat : ScriptableObject {
        [SerializeField, Range(0, 1)] private float m_InitialValue;
        [SerializeField, Range(0, 1)] private float m_CurrentValue;

        public event Action<float> OnChanged;

        public float Value {
            get { return m_CurrentValue; }
            set {
                if (Equals(m_CurrentValue, value)) { return; }

                m_CurrentValue = value;

                if (OnChanged != null) { OnChanged(value); }
            }
        }

        private void OnEnable() {
            Value = m_InitialValue;
        }
    }
}