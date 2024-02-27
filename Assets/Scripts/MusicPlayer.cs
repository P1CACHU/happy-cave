using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer : MonoBehaviour
{
	[SerializeField] private AudioClip[] _clips;
	[SerializeField] private AudioSource _source;

	private void Awake()
	{
		PlayNextSong();
	}

	private void PlayNextSong()
	{
		var clip = _clips[Random.Range(0, _clips.Length)];
		_source.clip = clip;
		_source.Play();
		Invoke(nameof(PlayNextSong), clip.length);
	}
}
