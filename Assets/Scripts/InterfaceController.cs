using System;
using DG.Tweening;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
	[SerializeField] private Transform _menuButton;
	[SerializeField] private Game _game;
	[SerializeField] private MenuView _menu;
	[SerializeField] private float _animationSpeed;

	private void Start()
	{
		_menu.CloseButtonClick += OnMenuCloseButtonClick;
		_menu.SoundToggleClick += OnMenuSoundToggleClick;
		_menu.MusicToggleClick += OnMenuMusicToggleClick;
		_menu.Hide(true);
	}

	private void OnDestroy()
	{
		_menu.CloseButtonClick -= OnMenuCloseButtonClick;
	}

	private void OnMenuMusicToggleClick(bool value)
	{
		MusicStateChanged?.Invoke(value);
	}

	private void OnMenuSoundToggleClick(bool value)
	{
		SoundStateChanged?.Invoke(value);
	}

	public event Action GamePaused;
	public event Action GameContinued;
	public event Action<bool> SoundStateChanged;
	public event Action<bool> MusicStateChanged;

	private void OnMenuCloseButtonClick()
	{
		GameContinued?.Invoke();
		_menu.Hide();
		_menuButton.DOScale(Vector3.one, _animationSpeed);
	}

	public void OnMenuButtonClick()
	{
		GamePaused?.Invoke();
		_menuButton.DOScale(Vector3.zero, _animationSpeed);
		_menu.Show();
		_menu.SetAudioState(_game.IsSoundsActive, _game.IsMusicActive);
	}
}
