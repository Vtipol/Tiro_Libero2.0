using Newtonsoft.Json;
using System;

[Serializable]
public sealed class SaveProfile<T> where T : SaveProfileData
{
    public string Name;
    public T SaveData;

    [JsonConstructor]
    public SaveProfile(string name, T saveData)
    {
        this.Name = name;
        this.SaveData = saveData;
    }

    public SaveProfile(string name)
    {
        this.Name = name;
    }
}
