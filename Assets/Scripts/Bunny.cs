using UnityEngine;

public class Bunny : MonoBehaviour
{
	private static readonly int IsRun = Animator.StringToHash("IsRun");

	[SerializeField] private float _speed;
	[SerializeField] private Animator _anim;

	private void Update()
	{
		transform.Translate(Vector3.right * (Input.GetAxis("Horizontal") * _speed));
		_anim.SetBool(IsRun, Input.GetAxis("Horizontal") != 0.0f);
	}
}
