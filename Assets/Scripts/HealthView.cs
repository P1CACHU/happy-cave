using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
	[SerializeField] private Image _icon;
	[SerializeField] private Vector3 _offset;

	private Transform _anchor;

	private void Update()
	{
		if (_anchor == null)
		{
			Debug.LogError("ANCHOR");
			return;
		}

		var cam = Camera.main;
		if (cam == null)
		{
			Debug.LogError("CAMERA");
			return;
		}
		
		var pos = cam.WorldToScreenPoint(_anchor.position);
		
		transform.position = pos + _offset;
	}

	public void SetValue(float value)
	{
		_icon.fillAmount = value / 100.0f;
	}

	public void SetAnchor(Transform anchor)
	{
		_anchor = anchor;
	}
}
