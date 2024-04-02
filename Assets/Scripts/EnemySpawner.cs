using Cainos.PixelArtTopDown_Basic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private LevelEnemyConfig _config;
	[SerializeField] private Transform[] _spawnPoints;

	private void Start()
	{
		var rndEnemy = _config.EnemyEntries[Random.Range(0, _config.EnemyEntries.Count)];
		var rndSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];


		var go = Instantiate(rndEnemy._prefab, rndSpawn);
		var comp = go.GetComponent<Enemy>();
		if (comp != null)
		{
			comp.Init(rndEnemy._damage, rndEnemy._health, rndEnemy._reward);
			comp.SetTartet(FindObjectOfType<TopDownCharacterController>().transform);
		}
	}
}
