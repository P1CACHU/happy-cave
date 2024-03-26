using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelEnemyConfig", menuName = "231226/Level Enemy Config")]
public class LevelEnemyConfig : ScriptableObject
{
	[SerializeField] private List<EnemyEntry> _enemyEntries;
	[SerializeField] private List<PlayerModel> _models;

	public List<EnemyEntry> EnemyEntries => _enemyEntries;
}

[Serializable]
public class EnemyEntry
{
	public GameObject _prefab;
	public int _health;
	public int _reward;
	public int _damage;
}
