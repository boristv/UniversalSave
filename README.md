# UniversalSave

- Easy use of saves
- Supports many data type (numeric types, unity vectors, Quaternion, Color, custom serializable structs and classes)
- 2 different types save storage - PlayerPrefs or File System
- 3 different serialization types - JsonUtility, JsonConvert, Binary
- Can save/load textures

## Requirements

- Unity 2020.3+
- Newtonsoft Json 3.0+

## Installation

- Import from package manager by local or git url (best way)
- Import unitypackage from releases (without examples)

## Instruction

Use the static class UniversalSave from namespace SG.Global.SaveSystem

- UniversalSave.Set - set data by key
- UniversalSave.Get - get data by key
- UniversalSave.TryGet - try get data by key
- UniversalSave.HasKey - check save key
- UniversalSave.Save - save data for all keys
- UniversalSave.DeleteKey - delete by key (for choosed save storage)
- UniversalSave.DeleteAll - delete all saved data (for choosed save storage)


- Methods for consistency with PlayerPrefs (for easy replacement PlayerPrefs.* to UniversalSave.*) 
To work without replacement with PlayerPrefs, you can immediately use just Set and Get - they work similarly.
  - UniversalSave.SetInt
  - UniversalSave.SetFloat
  - UniversalSave.SetString
  - UniversalSave.SetBool
  - UniversalSave.GetInt
  - UniversalSave.GetFloat
  - UniversalSave.GetString
  - UniversalSave.GetBool


- UniversalSave.SetImage - set Texture2D by key
- UniversalSave.TryGetImage - try get Texture2D by key


- UniversalSave.DefaultSettings - for change default UniversalSaveSettings


Also the editor has the ability to save any texture by selecting "Save image" in the context menu of the texture.


### UniversalSaveSettings

You can transfer different settings when using each method, or change the default settings at any time (within the game session).
It is important to use the same settings for saving and loading.

- StorageType - data storage (PlayerPrefs or FileSystem) (default - PlayerPrefs)
- FormatterType - serialization way (JsonUtility, JsonConvert, Binary) (default - JsonUtility)

Each has its own advantages and disadvantages. 

JsonConvert not work with unity types (but you can use Unity Converters for Newtonsoft.Json by jilleJr)
