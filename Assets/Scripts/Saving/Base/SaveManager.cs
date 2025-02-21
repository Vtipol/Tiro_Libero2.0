using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public static class SaveManager
{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/SaveData";

    public static void Delete(string profileName)
    {
        if (!File.Exists(path: SAVE_FOLDER + "/" + profileName))
        {
            Debug.LogError("Profile not found: " + profileName);
        }

        File.Delete(path: SAVE_FOLDER + "/" + profileName);
    }

    public static SaveProfile<T> Load<T>(string profileName) where T : SaveProfileData
    {
        if (!File.Exists(path: SAVE_FOLDER + "/" + profileName))
        {
            return null;
        }

        try
        {
            string deserializedData = File.ReadAllText(path: SAVE_FOLDER + "/" + profileName);

            //Debug.Log("Data: " + deserializedData);

            SaveProfile<T> saveProfile = JsonConvert.DeserializeObject<SaveProfile<T>>(deserializedData);
            return saveProfile;
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            return null;
        }
    }

    public static SaveProfileData Load(string profileName)
    {
        if (!File.Exists(path: SAVE_FOLDER + "/" + profileName))
        {
            return null;
        }

        try
        {
            string deserializedData = File.ReadAllText(path: SAVE_FOLDER + "/" + profileName);

            //Debug.Log("Data: " + deserializedData);

            SaveProfileData saveProfileData = JsonConvert.DeserializeObject<SaveProfileData>(deserializedData);
            return saveProfileData;
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            return null;
        }

    }

    public static bool Save<T>(SaveProfile<T> saveProfile) where T : SaveProfileData
    {
        if (File.Exists(path: SAVE_FOLDER + "/" + saveProfile.Name))
        {
            Debug.LogWarning($"Profile: {saveProfile.Name} already exists");
        }

        try
        {
            JsonSerializerSettings jsonSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            string serializedData = JsonConvert.SerializeObject
            (
                value: saveProfile,
                formatting: Formatting.Indented,
                settings: jsonSettings
            );

            Debug.Log(serializedData);

            if (!Directory.Exists(path: SAVE_FOLDER))
                Directory.CreateDirectory(path: SAVE_FOLDER);

            File.WriteAllText
            (
                path: SAVE_FOLDER + "/" + saveProfile.Name,
                contents: serializedData
            );

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    // Use reflection to automatically gather all fields, check if they were changed, and then save the eventual changes
    public static SaveProfile<T> Copy<T>(SaveProfile<T> profileToCopy) where T : SaveProfileData
    {
        JsonSerializerSettings jsonSettings = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };

        string serializedData = JsonConvert.SerializeObject
        (
            value: profileToCopy,
            formatting: Formatting.Indented,
            settings: jsonSettings
        );

        return JsonConvert.DeserializeObject<SaveProfile<T>>(serializedData);
    }


}
