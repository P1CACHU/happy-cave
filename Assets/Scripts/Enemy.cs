using UnityEngine;

public class Enemy : MonoBehaviour
{
	private int _damage;
	private int _health;
	private int _reward;

	public void Init(int damage, int health, int reward)
	{
		_damage = damage;
		_health = health;
		_reward = reward;
	}
}
