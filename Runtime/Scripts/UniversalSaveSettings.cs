namespace SG.Global.SaveSystem
{
    public class UniversalSaveSettings
    {
        public SerializationFormatterType FormatterType = SerializationFormatterType.JsonUtility;
        public DataStorageType StorageType = DataStorageType.PlayerPrefs;
        
        public bool UseSingleStorage = false;
        public string SingleStorageName = "saved_game_data";
    }
}
