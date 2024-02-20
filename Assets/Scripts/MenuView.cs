using System;
using DG.Tweening;
using UnityEngine;

public class MenuView : MonoBehaviour
{
	[SerializeField] private Transform _back;
	[SerializeField] private Transform _close;
	[SerializeField] private Transform _sound;
	[SerializeField] private Transform _music;
	[SerializeField] private float _animationSpeed;

	public event Action CloseButtonClick;

	public void Show()
	{
		gameObject.SetActive(true);

		var seq = DOTween.Sequence();
		seq.Append(_back.DOMove(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f), _animationSpeed));
		seq.Append(_close.DOScale(Vector3.one, _animationSpeed));
		seq.Join(_sound.DOScale(Vector3.one, _animationSpeed));
		seq.Join(_sound.DOShakeRotation(_animationSpeed));
		seq.Join(_music.DOScale(Vector3.one, _animationSpeed));
		seq.Join(_music.DOShakeRotation(_animationSpeed));
	}

	public void Hide(bool immediately = false)
	{
		var h = _back.GetComponent<RectTransform>().rect.height;

		var seq = DOTween.Sequence();
		seq.Append(_back.DOMove(new Vector3(Screen.width / 2, Screen.height + h, 0.0f),
			immediately ? 0.0f : _animationSpeed));
		seq.Append(_close.DOScale(Vector3.zero, 0.0f));
		seq.Join(_sound.DOScale(Vector3.zero, 0.0f));
		seq.Join(_music.DOScale(Vector3.zero, 0.0f));
		seq.AppendCallback(() => { gameObject.SetActive(false); });
	}

	public void OnCloseButtonClick()
	{
		CloseButtonClick?.Invoke();
	}
}
