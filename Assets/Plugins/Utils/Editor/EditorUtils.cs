using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Deviant.Utils {
	public static class EditorUtils {
		public static void OptionalUnserializedPropertyFieldGUILayout(object target, string propertyName, string label = null) {
			if (ReflectionUtils.HasProperty(target, propertyName)) { UnserializedPropertyFieldGUILayout(target, propertyName, label); }
		}

		private delegate T OnGUIDelegate<T>(string label, T value, params GUILayoutOption[] options);

		private static void UnserializedPropertyFieldGUILayout(object target, string propertyName, string label = null) {
			label = label ?? propertyName.ToSpacedName();

			Type valueType = ReflectionUtils.GetPropertyType(target, propertyName);

			if (valueType == null) { return; }

			if (valueType == typeof(bool)) { UnserializedPropertyFieldGUILayout<bool>(target, propertyName, label, EditorGUILayout.Toggle); }
			else if (valueType == typeof(int)) { UnserializedPropertyFieldGUILayout<int>(target, propertyName, label, EditorGUILayout.IntField); }
			else if (valueType == typeof(float)) { UnserializedPropertyFieldGUILayout<float>(target, propertyName, label, EditorGUILayout.FloatField); }
			else if (valueType == typeof(string)) { UnserializedPropertyFieldGUILayout<string>(target, propertyName, label, EditorGUILayout.TextField); }
			else if (valueType == typeof(Vector2)) { UnserializedPropertyFieldGUILayout<Vector2>(target, propertyName, label, EditorGUILayout.Vector2Field); }
			else if (valueType == typeof(Vector3)) { UnserializedPropertyFieldGUILayout<Vector3>(target, propertyName, label, EditorGUILayout.Vector3Field); }
			else if (valueType == typeof(Color)) { UnserializedPropertyFieldGUILayout<Color>(target, propertyName, label, EditorGUILayout.ColorField); }
			else if (typeof(Object).IsAssignableFrom(valueType)) { UnserializedPropertyFieldGUILayout<Object>(target, propertyName, label, (l, v, p) => EditorGUILayout.ObjectField(l, v, valueType, true, p)); }
			else if (valueType.IsEnum) { UnserializedPropertyFieldGUILayout<Enum>(target, propertyName, label, EditorGUILayout.EnumPopup); }
			else { Debug.LogError("Can't find generic GUI for type " + valueType.Name); }
		}

		private static void UnserializedPropertyFieldGUILayout<T>(object target, string propertyName, string label, OnGUIDelegate<T> onGUI) {
			T currentValue = ReflectionUtils.GetPropertyValue<T>(target, propertyName);
			T newValue = onGUI(label, currentValue);
			if (!Equals(newValue, currentValue)) { ReflectionUtils.SetPropertyValue(target, propertyName, newValue); }
		}
	}
}