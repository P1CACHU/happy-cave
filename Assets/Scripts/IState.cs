public interface IState<T>
{
	void Execute(T owner);
}
