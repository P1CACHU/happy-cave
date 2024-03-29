using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

namespace MyNamespace
{
	public class Bunny : MonoBehaviour
	{
		private const int InitialNumber = 3;
		private const string HorizontalAxisName = "Horizontal";
		private static readonly int IsRun = Animator.StringToHash("IsRun");

		[SerializeField] private float _speed;
		[SerializeField] private Animator _anim;

		private void Update()
		{
			transform.Translate(Vector3.right * (Input.GetAxis(HorizontalAxisName) * _speed));
			_anim.SetBool(IsRun, Input.GetAxis(HorizontalAxisName) != 0.0f);
		}

		private void OnDestroy()
		{
			_anim.SetBool(IsRun, Input.GetAxis(HorizontalAxisName) != 0.0f);
		}

		public bool GetSpecial(int number)
		{
			return number > InitialNumber;
		}
	}
}
