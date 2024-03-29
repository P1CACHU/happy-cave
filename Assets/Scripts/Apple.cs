using DG.Tweening;
using UnityEngine;

public class Apple : MonoBehaviour
{
	[SerializeField] private float _animationTime;

	public void MoveTo(Vector3 pos)
	{
		transform.DOMove(pos, 1.0f).OnComplete(Destroy);
	}

	public void MoveToWithTime(Vector3 pos, float time)
	{
		transform.DOMove(pos, time);
	}

	private void Destroy()
	{
		gameObject.SetActive(false);
		Destroy(gameObject, 3);
	}
}
