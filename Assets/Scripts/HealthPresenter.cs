using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPresenter : MonoBehaviour, IDamageHandler<Damage>
{
	[SerializeField] private HealthView _prefab;

	private PlayerModel _model;
	private ISaver<PlayerModel> _saver;
	private HealthView _view;

	private void Awake()
	{
		_view = Instantiate(_prefab, FindObjectOfType<InterfaceController>().transform);
		_view.SetAnchor(transform);

		_saver = new JsonSaver();
		if (Application.platform == RuntimePlatform.OSXEditor)
		{
			_saver = new XmlSaver();
		}
		_model = _saver.Load();

		_model.DataChanged += OnModelDataChanged;
		_view.SetValue(_model.Health);
	}

	private void OnDestroy()
	{
		_model.DataChanged -= OnModelDataChanged;
	}

	public void Handle(Damage dmg)
	{
		_model.Health -= dmg.Amount;
	}

	private void OnModelDataChanged()
	{
		if (_model.Health <= 0)
		{
			SceneManager.LoadScene("Scenes/Main");
			return;
		}

		_view.SetValue(_model.Health);
		_saver.Save(_model);
	}
}
