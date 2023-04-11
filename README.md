# UniversalSave

- Need Unity version 2021+
- Easy use of saves
- Supports many data type (numeric types, unity vectors, Quaternion, Color, custom serializable structs and classes)
- 2 different types save storage - PlayerPrefs or File System
- 3 different serialization types - JsonUtility, JsonConvert, Binary
- Can save/load textures

## Installation

- Import unitypackage from releases
- If examples aren't needed, uncheck the folder "Examples"

## Instruction

Use the static class UniversalSave from namespace SG.GLobal.SaveSystem

- UniversalSave.Save - save data by key
- UniversalSave.Load - load data by key
- UniversalSave.TryLoad - try load data by key
- UniversalSave.HasKey - check save key
- UniversalSave.Clear - clear by key (for choosed save storage)
- UniversalSave.ClearAll - clear all saved data (for choosed save storage)

- UniversalSave.SaveImage - save Texture2D by key
- UniversalSave.TryLoadImage - try load Texture2D by key

- UniversalSave.DefaultSettings - for change default UniversalSaveSettings


### UniversalSaveSettings

You can transfer different settings when using each method, or change the default settings at any time (within the game session).
It is important to use the same settings for saving and loading.

- StorageType - data storage (PlayerPrefs or FileSystem) (default - PlayerPrefs)
- FormatterType - serialization way (JsonUtility, JsonConvert, Binary) (default - JsonUtility)

Each has its own advantages and disadvantages. 

JsonConvert not work with unity types (but you can use Unity Converters for Newtonsoft.Json by jilleJr)
