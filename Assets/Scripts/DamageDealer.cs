using UnityEngine;

public class DamageDealer : MonoBehaviour
{
	[SerializeField] private int _damage;

	private void OnTriggerEnter2D(Collider2D other)
	{
		var comp = other.GetComponent<HealthPresenter>();
		if (comp != null)
		{
			comp.Handle(new Damage(_damage));
		}
	}
}
