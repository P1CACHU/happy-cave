using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XmlSaver : ISaver<PlayerModel>
{
	private const string fileName = "gameSave.xml";
	private static XmlSerializer _serializer;

	public XmlSaver()
	{
		_serializer = new XmlSerializer(typeof(PlayerModel));
	}

	public void Save(PlayerModel value)
	{
		if (value == null && !string.IsNullOrEmpty(Path.Combine(Application.persistentDataPath, fileName)))
		{
			return;
		}

		using var fs = new FileStream(Path.Combine(Application.persistentDataPath, fileName), FileMode.Create);
		_serializer.Serialize(fs, value);
	}

	public PlayerModel Load()
	{
		if (!File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
		{
			return new PlayerModel();
		}

		using var fs = new FileStream(Path.Combine(Application.persistentDataPath, fileName), FileMode.Open);
		return (PlayerModel)_serializer.Deserialize(fs);
	}
}
