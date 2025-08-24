using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData 
{
    private string fileName;
    private string directory;

    public SaveData(string _fileName, string _directory)
    {
        fileName = _fileName;
        directory = _directory;
    }

    public string GetFullPath() => GetDriectory() + "/" + fileName + ".json";

    public string GetDriectory() => Application.persistentDataPath + "/" + directory;
}