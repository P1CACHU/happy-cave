using UnityEngine;
using UnityEngine.Audio;

public class Game : MonoBehaviour
{
	private const string FullSnapshotName = "Full";
	private const string MusicOnlySnapshotName = "MusicOnly";
	private const string SoundsOnlySnapshotName = "SoundOnly";
	private const string MuteSnapshotName = "Mute";
	private const string MusicActivePrefsKey = "MusicActivePrefsKey";
	private const string SoundsActivePrefsKey = "SoundsActivePrefsKey";

	[SerializeField] private InterfaceController _interface;
	[SerializeField] private AudioMixer _mixer;

	public bool IsMusicActive { get; private set; }

	public bool IsSoundsActive { get; private set; }

	private void Awake()
	{
		_interface.GamePaused += Pause;
		_interface.GameContinued += Continue;
		_interface.SoundStateChanged += ToggleSounds;
		_interface.MusicStateChanged += ToggleMusic;
	}

	private void Start()
	{
		LoadSoundState();
	}

	private void OnDestroy()
	{
		_interface.GamePaused -= Pause;
		_interface.GameContinued -= Continue;
		_interface.SoundStateChanged -= ToggleSounds;
		_interface.MusicStateChanged -= ToggleMusic;
	}

	private void ChangeSoundState()
	{
		var snapshot = FullSnapshotName;
		if (!IsSoundsActive)
		{
			snapshot = IsMusicActive ? MusicOnlySnapshotName : MuteSnapshotName;
		}

		if (!IsMusicActive)
		{
			snapshot = IsSoundsActive ? SoundsOnlySnapshotName : MuteSnapshotName;
		}

		_mixer.FindSnapshot(snapshot).TransitionTo(0.0f);
		SaveSoundState();
	}

	private void SaveSoundState()
	{
		PlayerPrefs.SetInt(SoundsActivePrefsKey, IsSoundsActive ? 1 : 0);
		PlayerPrefs.SetInt(MusicActivePrefsKey, IsMusicActive ? 1 : 0);
		PlayerPrefs.Save();
	}

	private void LoadSoundState()
	{
		IsSoundsActive = PlayerPrefs.GetInt(SoundsActivePrefsKey) != 0;
		IsMusicActive = PlayerPrefs.GetInt(MusicActivePrefsKey) != 0;
		ChangeSoundState();
	}

	private void Pause()
	{
		Time.timeScale = 0.0f;
	}

	private void Continue()
	{
		Time.timeScale = 1.0f;
	}

	private void ToggleSounds(bool value)
	{
		IsSoundsActive = value;
		ChangeSoundState();
	}

	private void ToggleMusic(bool value)
	{
		IsMusicActive = value;
		ChangeSoundState();
	}
}