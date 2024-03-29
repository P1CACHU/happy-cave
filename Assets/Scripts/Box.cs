using UnityEngine;
using Random = UnityEngine.Random;

public class Box : MonoBehaviour
{
	[SerializeField] private Apple applePrefab;
	[SerializeField] private PropsHealth propsHealth;
	[SerializeField] private float maxDistance;
	[SerializeField] private int appleCount;
	[SerializeField] private float delay;

	private Vector3 position;

	private void Start()
	{
		propsHealth.OnDestroy += DrawReward;
		position = transform.position;
	}

	private void DrawReward()
	{
		for (var i = 0; i < appleCount; i++)
		{
			var newApple = Instantiate(applePrefab, transform.position, Quaternion.identity);
			var randomComp = Random.Range(-maxDistance, maxDistance);
			newApple.MoveToWithTime(new Vector3(position.x + randomComp, position.y + randomComp, position.z), 2);
		}
		
		DestroyBox();
	}

	private void DestroyBox()
	{
		Destroy(gameObject);
	}
}
