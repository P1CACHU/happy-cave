public interface ISaver<T>
{
	void Save(T value);
	T Load();
}
