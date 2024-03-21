
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

public class AttackMechanics : MonoBehaviour
{
	[SerializeField] private TopDownCharacterController characterController;
	[SerializeField] private DamageDealer dealer;
	[SerializeField] private Transform whipPoint;
	[SerializeField] private float distance;
	[SerializeField] private float attackSpeed;
	

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
			whipPoint.localScale = new Vector3(1, 0, 1);
		}
	}
}