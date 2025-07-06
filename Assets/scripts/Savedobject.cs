using System.Collections.Generic;
using UnityEngine;


public interface ISaveable
{
    void LoadData(SavedObject data);
    SavedObject GetSaveData();
}

[System.Serializable]


       public class SavedObject
    {
        public string prefabName; 
        public Vector3 position;
        public Quaternion rotation;
        public int value;
        public float sspeed;
        public Dictionary<string, string> customData;
     
    }

