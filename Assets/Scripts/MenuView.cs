using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
	[SerializeField] private Transform _back;
	[SerializeField] private Transform _close;
	[SerializeField] private Toggle _sound;
	[SerializeField] private Toggle _music;
	[SerializeField] private float _animationSpeed;
	[SerializeField] private UnityEvent<bool> _onValueChanged;

	public event Action CloseButtonClick;
	public event Action<bool> SoundToggleClick;
	public event Action<bool> MusicToggleClick;

	public void SetAudioState(bool sounds, bool music)
	{
		_sound.isOn = sounds;
		_music.isOn = music;
	}

	public void Show(Action callback)
	{
		gameObject.SetActive(true);

		var seq = DOTween.Sequence();
		seq.Append(_back.DOMove(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f), _animationSpeed));
		seq.Append(_close.DOScale(Vector3.one, _animationSpeed));
		seq.Join(_sound.transform.DOScale(Vector3.one, _animationSpeed));
		seq.Join(_sound.transform.DOShakeRotation(_animationSpeed));
		seq.Join(_music.transform.DOScale(Vector3.one, _animationSpeed));
		seq.Join(_music.transform.DOShakeRotation(_animationSpeed));
		seq.AppendCallback(() => { callback?.Invoke(); });
	}

	public void Hide(Action callback, bool immediately = false)
	{
		var h = _back.GetComponent<RectTransform>().rect.height;

		var seq = DOTween.Sequence();
		seq.Append(_back.DOMove(new Vector3(Screen.width / 2, Screen.height + h, 0.0f),
			immediately ? 0.0f : _animationSpeed));
		seq.Append(_close.DOScale(Vector3.zero, 0.0f));
		seq.Join(_sound.transform.DOScale(Vector3.zero, 0.0f));
		seq.Join(_music.transform.DOScale(Vector3.zero, 0.0f));
		seq.AppendCallback(() =>
		{
			gameObject.SetActive(false);
			callback?.Invoke();
		});
	}

	public void OnCloseButtonClick()
	{
		CloseButtonClick?.Invoke();
	}

	public void OnSoundToggleClick(bool value)
	{
		SoundToggleClick?.Invoke(value);
	}

	public void OnMusicToggleClick(bool value)
	{
		MusicToggleClick?.Invoke(value);
	}
}
