
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

public class AttackMechanics : MonoBehaviour
{
	[SerializeField] private TopDownCharacterController characterController;
	[SerializeField] private DamageDealer dealer;
	[SerializeField] private Transform whipPoint;
	[SerializeField] private float distance;
	[SerializeField] private float attackSpeed;
	
	private readonly Vector3 initialScale = new(1, 0, 1);

	private void Start()
	{
		dealer.IsActive = false;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.E) && whipPoint.localScale.y < distance)
		{
			dealer.IsActive = true;
			whipPoint.transform.up = -characterController.DirectionOfView;
			var localScale = whipPoint.localScale;
			localScale.y += Time.deltaTime * attackSpeed;
			whipPoint.localScale = localScale;
		}
		else 
		{
			dealer.IsActive = false;
			whipPoint.localScale = initialScale;
		}
	}
}
