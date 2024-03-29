using System;

[Serializable]
public class PlayerModel
{
	public int _apples;
	public int _experience;
	public int _health = 100;

	public int Health
	{
		get => _health;
		set
		{
			if (value != _health)
			{
				_health = value;
				DataChanged?.Invoke();
			}
		}
	}

	public int Experience
	{
		get => _experience;
		set
		{
			if (value != _experience)
			{
				_experience = value;
				DataChanged?.Invoke();
			}
		}
	}

	public int Apples
	{
		get => _apples;
		set
		{
			if (value != _apples)
			{
				_apples = value;
				DataChanged?.Invoke();
			}
		}
	}

	public event Action DataChanged;
}
