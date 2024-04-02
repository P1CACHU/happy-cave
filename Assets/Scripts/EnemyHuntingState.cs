using UnityEngine;

public class EnemyHuntingState : IState<Enemy>
{
	public void Execute(Enemy owner)
	{
		if (!owner.CheckDistance())
		{
			owner.SetState(EnemyState.Waiting);
		}
		owner.SetHuntingState(true);
	}
}
