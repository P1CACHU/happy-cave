using System;
using UnityEngine;

public class HealthModel
{
	private float _amount;
	public event Action DataChanged;

	public HealthModel(float amount)
	{
		_amount = amount;
	}

	public float Amount
	{
		get => _amount;
		set
		{
			if (!Mathf.Approximately(value, _amount))
			{
				_amount = value;
				DataChanged?.Invoke();
			}
		}
	}
}