using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPresenter : MonoBehaviour, IDamageHandler<Damage>
{
	private const string PlayerHealthAmountKey = "PlayerHealthAmountKey";

	[SerializeField] private float _hp = 100.0f;
	[SerializeField] private HealthView _prefab;

	private HealthModel _model;
	private HealthView _view;

	private void Awake()
	{
		_view = Instantiate(_prefab, FindObjectOfType<InterfaceController>().transform);
		_view.SetAnchor(transform);

		if (PlayerPrefs.HasKey(PlayerHealthAmountKey))
		{
			_model = new HealthModel(PlayerPrefs.GetFloat(PlayerHealthAmountKey));
		}
		else
		{
			_model = new HealthModel(_hp);
		}

		_model.DataChanged += OnModelDataChanged;
		_view.SetValue(_model.Amount);
	}

	private void OnDestroy()
	{
		_model.DataChanged -= OnModelDataChanged;
	}

	public void Handle(Damage dmg)
	{
		_model.Amount -= dmg.Amount;
	}

	private void OnModelDataChanged()
	{
		if (_model.Amount <= 0.0f)
		{
			PlayerPrefs.DeleteKey(PlayerHealthAmountKey);
			SceneManager.LoadScene("Scenes/Main");
			return;
		}

		_view.SetValue(_model.Amount);
		PlayerPrefs.SetFloat(PlayerHealthAmountKey, _model.Amount);
		PlayerPrefs.Save();
	}
}