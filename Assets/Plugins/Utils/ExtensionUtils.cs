using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Deviant.Utils {
	public static class ExtensionUtils {
		public static bool Approximately(this float a, float b, float epsilon = float.Epsilon) { return Math.Abs(a - b) < epsilon; }

		public static Color SetAlpha(this Color color, float value) { return new Color(color.r, color.g, color.b, value); }
	}
}