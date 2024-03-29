using System;
using System.IO;
using UnityEngine;

public class FileSaver : ISaver<PlayerModel>
{
	private const string FileName = "gameSave.hcsd";

	public void Save(PlayerModel value)
	{
		using var sw = new StreamWriter(Path.Combine(Application.persistentDataPath, FileName));
		sw.WriteLine(value.Health);
		sw.WriteLine(value.Experience);
		sw.WriteLine(value.Apples);
	}

	public PlayerModel Load()
	{
		var model = new PlayerModel();

		using var sr = new StreamReader(Path.Combine(Application.persistentDataPath, FileName));
		while (!sr.EndOfStream)
		{
			model.Health = Convert.ToInt32(sr.ReadLine());
			model.Experience = Convert.ToInt32(sr.ReadLine());
			model.Apples = Convert.ToInt32(sr.ReadLine());
		}

		return model;
	}
}
