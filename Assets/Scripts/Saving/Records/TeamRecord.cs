using System;
using System.Collections.Generic;

[Serializable]
public record TeamRecord : SaveProfileData
{
    public string Name;
    public List<PlayerRecord> PlayerRecords;
}
