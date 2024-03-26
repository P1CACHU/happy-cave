using UnityEngine;

public class PlayerPrefsSave : ISaver<float>
{
	private const string PlayerHealthAmountKey = "PlayerHealthAmountKey";
	private const float HealthPoints = 100.0f;

	public void Save(float amount)
	{
		PlayerPrefs.SetFloat(PlayerHealthAmountKey, amount);
		PlayerPrefs.Save();
	}

	public float Load()
	{
		return PlayerPrefs.GetFloat(PlayerHealthAmountKey, HealthPoints);
	}
}
