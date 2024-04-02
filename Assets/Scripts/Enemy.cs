using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public enum EnemyState
{
	Waiting,
	Hunting
}

public class Enemy : MonoBehaviour
{
	[SerializeField] private AIDestinationSetter _destinationSetter;
	[SerializeField] private AIPath _path;
	[SerializeField] private float _castRadius;

	private Dictionary<EnemyState, IState<Enemy>> _states;
	private IState<Enemy> _currentState;

	private int _damage;
	private int _health;
	private int _reward;
	private Transform _target;

	private void Start()
	{
		_states = new Dictionary<EnemyState, IState<Enemy>>
		{
			{ EnemyState.Waiting, new EnemyWaitingState() },
			{ EnemyState.Hunting, new EnemyHuntingState() }
		};
		_currentState = _states[EnemyState.Waiting];
	}

	private void Update()
	{
		_currentState.Execute(this);
	}

	public void Init(int damage, int health, int reward)
	{
		_damage = damage;
		_health = health;
		_reward = reward;
	}

	public void SetTartet(Transform target)
	{
		_target = target;
	}

	public void SetState(EnemyState state)
	{
		_currentState = _states[state];
	}

	public bool CheckDistance()
	{
		if (_target is null)
		{
			return false;
		}

		return Vector3.Distance(transform.position, _target.position) < _castRadius;
	}

	public void SetHuntingState(bool isActive)
	{
		_destinationSetter.target = isActive ? _target : null;
	}
}
