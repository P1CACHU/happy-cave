using UnityEngine;

public class DamageDealer : MonoBehaviour
{
	[SerializeField] private float _damage;

	public bool IsActive;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!IsActive) return;
		
		var comp = other.GetComponent<IDamageHandler<Damage>>();
		if (comp != null)
		{
			comp.Handle(new Damage(_damage));
		}
	}
}
