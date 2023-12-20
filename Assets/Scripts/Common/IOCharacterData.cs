using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class IOCharacterData : MonoBehaviour
{
    //public CharacterData[] characters;

    //private string filePath;

    //public static IOCharacterData instance;
    //private void Awake()
    //{

    //    instance = this;

    //    filePath = Application.persistentDataPath + "/characterData.json";
    //    if (!File.Exists(filePath))
    //    {
    //        SaveCharacterData();
    //    }
    //    LoadCharacterData();


    //}

    //public void SaveCharacterData()
    //{
    //    // Chuyển đổi mảng CharacterData thành JSON
    //    string json = JsonUtility.ToJson(new CharacterDataArray { characterss = characters });
    //    File.WriteAllText(filePath, json);
    //    Debug.Log("Đã ghi file");
    //    LoadCharacterData();
    //}

    //private void LoadCharacterData()
    //{
    //    Debug.Log(filePath);
    //    if (File.Exists(filePath))
    //    {
    //        string json = File.ReadAllText(filePath);
    //        CharacterDataArray loadedData = JsonUtility.FromJson<CharacterDataArray>(json);
    //        ApplyCharacterData(loadedData.characterss);
    //    }
    //}

    //private void ApplyCharacterData(CharacterData[] loadedCharacters)
    //{
    //    for (int i = 0; i < characters.Length; i++)
    //    {
    //        characters[i] = loadedCharacters[i];
    //        Debug.Log("Đọc xong");
    //        Debug.Log(characters[i].health);
    //    }
    //}
    //private void OnApplicationQuit()
    //{
    //    SaveCharacterData();
    //}

    //[System.Serializable]
    //private class CharacterDataArray
    //{
    //    public CharacterData[] characterss;
    //}
    public static IOCharacterData instance;
    private const string assetPath = "Assets/Scripts/SO/Characters/";
    public  CharacterData[] dataCharacters;
    public  CharacterData[] LoadArrayOfScriptableObjects()
    {
        // Đọc tất cả tệp tin ScriptableObject trong thư mục Resources
        string[] arrayPath = AssetDatabase.FindAssets("t:CharacterData", new[] { assetPath });

        if (arrayPath.Length > 0)
        {
            CharacterData[] dataArray = new CharacterData[arrayPath.Length];

            for (int i = 0; i < arrayPath.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(arrayPath[i]);
                dataArray[i] = AssetDatabase.LoadAssetAtPath<CharacterData>(assetPath);
            }

            return dataArray;
        }

        return null;
    }

    private void Awake()
    {
        instance = this;
        dataCharacters = LoadArrayOfScriptableObjects();
        //foreach(CharacterData dataObj in dataCharacters)
        //{
        //    Debug.Log( dataObj.characterName);
        //}
    }

    public void ChangeScriptableObjectData(CharacterData character)
    {

        if (character != null)
        {
            GetAssetPath(character);
            // Thay đổi dữ liệu của ScriptableObject
            Debug.Log("Đã lưu" + character.name);
            // Lưu lại thay đổi
            EditorUtility.SetDirty(character);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError("Not found scriptableObject.");
        }
    }


    private string GetAssetPath(Object obj)
    {
        return AssetDatabase.GetAssetPath(obj);
    }
}
