using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private InterfaceController _interface;

	private void Awake()
	{
		_interface.GamePaused += Pause;
		_interface.GameContinued += Continue;
	}

	private void OnDestroy()
	{
		_interface.GamePaused -= Pause;
		_interface.GameContinued -= Continue;
	}

	private void Pause()
	{
		Time.timeScale = 0.0f;
	}

	private void Continue()
	{
		Time.timeScale = 1.0f;
	}
}
