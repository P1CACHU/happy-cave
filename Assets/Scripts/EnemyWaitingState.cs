using UnityEngine;

public class EnemyWaitingState : IState<Enemy>
{
	public void Execute(Enemy owner)
	{
		if (owner.CheckDistance())
		{
			owner.SetState(EnemyState.Hunting);
		}
		owner.SetHuntingState(false);
	}
}
