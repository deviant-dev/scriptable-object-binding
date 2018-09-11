using System;
using UnityEngine;

namespace Utils {
	public static class Extensions {
		public static bool Approximately(this float a, float b, float epsilon = float.Epsilon) { return Math.Abs(a - b) < epsilon; }

		public static Color SetAlpha(this Color color, float value) { return new Color(color.r, color.g, color.b, value); }
	}
}