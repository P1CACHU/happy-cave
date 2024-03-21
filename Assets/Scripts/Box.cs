using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Box : MonoBehaviour
{
	[SerializeField] private Apple applePrefab;
	[SerializeField] private PropsHealth propsHealth;
	[SerializeField] private float maxDistance;
	[SerializeField] private int appleCount;
	[SerializeField] private int delay;

	private Vector3 position;

	private void Start()
	{
		propsHealth.OnDestroy += OnDestroyBox;
		position = transform.position;
	}

	private void OnDestroyBox()
	{
		for (int i = 0; i < appleCount; i++)
		{
			var newApple = Instantiate(applePrefab, transform.position, Quaternion.identity);
			float randomComp = Random.Range(-maxDistance, maxDistance);
			newApple.transform.DOMove(
				new Vector3(position.x + randomComp, position.y + randomComp, position.z),
				2);
		}
		DestroyBox();
	}
	
	private void DestroyBox()
	{
		Destroy(gameObject);
	}
}
