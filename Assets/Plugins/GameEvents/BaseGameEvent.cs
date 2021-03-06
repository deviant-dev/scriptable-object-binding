﻿using System;
using UnityEngine;
using Deviant.Utils;

namespace Deviant.GameEvents {
	public abstract class BaseGameEvent : ScriptableObject {
		[SerializeField] private string m_EventName;
		[SerializeField, Multiline] private string m_EventDescription;
		[SerializeField] private bool m_DebugLog;

		public event Action GenericEvent;

		public string Name { get { return m_EventName.IsNullOrEmpty() ? name : m_EventName; } }

		protected void OnEnable() { Init(); }

		protected virtual void Init() { GenericEvent = null; }

		protected abstract void RaiseDefault();

		protected string DataInfo { private get; set; }

		protected void RaiseGeneric() {
			if (m_DebugLog) { Debug.LogFormat(this, "Raise {0}{1}", name, DataInfo); }

			if (GenericEvent != null) { GenericEvent(); }
		}

		public void Raise() { RaiseDefault(); }
	}

	public abstract class BaseGameEvent<thisT, T> : BaseGameEvent where thisT : BaseGameEvent<thisT, T> {
		public event Action<T> Event;

		protected override void Init() {
			base.Init();
			Event = null;
		}

		protected override void RaiseDefault() { Raise(default(T)); }

		public void Raise(T value) {
			DataInfo = string.Format("({0})", value == null ? "--null--" : value.ToString());
			RaiseGeneric();

			if (Event != null) { Event(value); }
		}
	}
}