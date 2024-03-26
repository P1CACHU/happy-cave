using UnityEngine;

public abstract class AbstractPlayer : MonoBehaviour
{
	private bool _isDead;
	public bool _isDeadPU;
	protected bool _isDeadPR;
	
	public abstract void SetHealthPoints();

	public bool GetHealthPoints()
	{
		return _isDead;
	}
}
