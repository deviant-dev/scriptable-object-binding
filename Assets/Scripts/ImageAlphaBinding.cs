using GameVariables;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class ImageAlphaBinding : MonoBehaviour {
	[SerializeField] private GameVariableFloatRange m_RangeVariable;
	[SerializeField] private Image m_Image;

	private void Start() { m_RangeVariable.OnChanged += OnVariableChanged; }

	private void OnVariableChanged(float value) { m_Image.color = m_Image.color.SetAlpha(value); }
}