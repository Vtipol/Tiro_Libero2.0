using System;

public static class StatsSaver
{
    private static readonly string DATE_FORMATTER = "yyyy-MM-dd HH-mm-ss";

    public static bool Save(GameRecord gameRecord)
    {
        // Get date, with hours, minutes and seconds
        DateTime dateTime = DateTime.Now;
        string formattedDate = dateTime.ToString(DATE_FORMATTER);

        // Use it as a name to get a unique name for each Game
        SaveProfile<GameRecord> saveProfile = new(formattedDate, gameRecord);

        return SaveManager.Save(saveProfile);
    }

    public static SaveProfile<GameRecord> Load(string name)
    {
        return SaveManager.Load<GameRecord>(name);
    }
}
