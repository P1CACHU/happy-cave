using DG.Tweening;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
	public class TopDownCharacterController : MonoBehaviour
	{
		public float speed;
		public Vector2 DirectionOfView => directionOfView;

		private Animator animator;
		private Vector2 direction;
		private Vector2 directionOfView;
		
		private static readonly int AnimDirection = Animator.StringToHash("Direction");
		private static readonly int AnimIsMoving = Animator.StringToHash("IsMoving");

		private void Start()
		{
			animator = GetComponent<Animator>();
		}


		private void Update()
		{
			direction = Vector2.zero;
			if (Input.GetKey(KeyCode.A))
			{
				direction.x = directionOfView.x = -1;
				animator.SetInteger(AnimDirection, 3);
			}
			else if (Input.GetKey(KeyCode.D))
			{
				direction.x = directionOfView.x = 1;
				animator.SetInteger(AnimDirection, 2);
			}

			if (Input.GetKey(KeyCode.W))
			{
				direction.y = directionOfView.y = 1;
				animator.SetInteger(AnimDirection, 1);
			}
			else if (Input.GetKey(KeyCode.S))
			{
				direction.y = directionOfView.y = -1;
				animator.SetInteger(AnimDirection, 0);
			}

			direction.Normalize();
			directionOfView.Normalize();
			animator.SetBool(AnimIsMoving, direction.magnitude > 0);
			GetComponent<Rigidbody2D>().velocity = speed * direction;

			if (Mathf.Abs(directionOfView.y) > Mathf.Abs(directionOfView.x))
				directionOfView.x = 0;
			else
				directionOfView.y = 0;
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			Debug.Log("collision");

			var apple = col.gameObject.GetComponent<Apple>();
			if (apple != null)
			{
				var pos = Camera.main.ScreenToWorldPoint(FindObjectOfType<scoreCounter>().transform.position);
				apple.transform.DOMove(pos, 1.0f).OnComplete(() => { Destroy(apple.gameObject); });
			}
		}
	}
}