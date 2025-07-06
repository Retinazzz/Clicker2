using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    
    public static void SaveObjects(List<GameObject> objectsToSave)
    {
        List<SavedObject> savedObjects = new List<SavedObject>();

        foreach (var obj in objectsToSave)
        {
            SavedObject data = new SavedObject
            {
                prefabName = obj.name.Replace("(Clone)", ""), // Удаляем "(Clone)" у спавнящихся объектов
                position = obj.transform.position,
                rotation = obj.transform.rotation,
                customData = new Dictionary<string, string>()
            };
            savedObjects.Add(data);
        }

        string json = JsonUtility.ToJson(savedObjects);
        File.WriteAllText(Application.persistentDataPath + "/savedObjects.json", json);
    }
    public static void LoadObjects()
    {
        if (File.Exists(Application.persistentDataPath + "/savedObjects.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savedObjects.json");
            List<SavedObject> loadedObjects = JsonUtility.FromJson<List<SavedObject>>(json);

            foreach (var data in loadedObjects)
            {
                GameObject prefab = Resources.Load<GameObject>(data.prefabName);
                if (prefab != null)
                {
                    GameObject obj = Instantiate(prefab, data.position, data.rotation);
                    // Восстанавливаем доп. параметры (например, HP)
                }
            }
        }
    }
}
