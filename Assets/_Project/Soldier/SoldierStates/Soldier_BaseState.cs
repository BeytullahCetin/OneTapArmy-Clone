public abstract class Soldier_BaseState
{
	protected Soldier soldier;

	public abstract void EnterStateLogic();
	public abstract void ExitStateLogic();

	public virtual void UpdateState() { }

	public virtual void EnterState(Soldier soldier)
	{
		this.soldier = soldier;
		EnterStateLogic();
	}

	public virtual void ExitState(Soldier tsm)
	{
		ExitStateLogic();
	}
}