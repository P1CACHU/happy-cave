using System.IO;
using UnityEngine;

public class JsonSaver : ISaver<PlayerModel>
{
	private const string FileName = "gameSave.json";

	public void Save(PlayerModel value)
	{
		var str = JsonUtility.ToJson(value);
		File.WriteAllText(Path.Combine(Application.persistentDataPath, FileName), str);
	}

	public PlayerModel Load()
	{
		if (!File.Exists(Path.Combine(Application.persistentDataPath, FileName)))
		{
			return new PlayerModel();
		}

		var str = File.ReadAllText(Path.Combine(Application.persistentDataPath, FileName));
		return JsonUtility.FromJson<PlayerModel>(str);
	}
}
