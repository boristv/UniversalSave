namespace SG.Global.SaveSystem
{
    public class UniversalSaveSettings
    {
        public SerializationFormatterType FormatterType;
        public DataStorageType StorageType;

        public UniversalSaveSettings()
        {
            FormatterType = SerializationFormatterType.JsonUtility;
            StorageType = DataStorageType.PlayerPrefs;
        }
    }
}
