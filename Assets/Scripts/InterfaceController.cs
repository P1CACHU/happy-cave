using System;
using DG.Tweening;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
	[SerializeField] private Transform _menuButton;
	[SerializeField] private MenuView _menu;
	[SerializeField] private float _animationSpeed;

	private void Start()
	{
		_menu.CloseButtonClick += OnMenuCloseButtonClick;
		_menu.Hide(true);
	}

	private void OnDestroy()
	{
		_menu.CloseButtonClick -= OnMenuCloseButtonClick;
	}

	public event Action GamePaused;
	public event Action GameContinued;

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
	}
}
