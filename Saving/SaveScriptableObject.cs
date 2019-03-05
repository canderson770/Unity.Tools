using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

namespace Saving
{
    public class SaveScriptableObject : MonoBehaviour
    {
        private BinaryFormatter bf = new BinaryFormatter();
        [SerializeField] private ScriptableObjectAction scriptableObject;
        //[SerializeField] private string saveLocation;

        private void Awake()
        {
            //  Load at begining of game
            Load();

            //  Save whenever object is changed
            if (scriptableObject != null) scriptableObject.OnChange += Save;
        }

        private void OnDestroy()
        {
            //  Save at end of game
            Save();

            if (scriptableObject != null) scriptableObject.OnChange -= Save;
        }

        public void ShowSaveLocation()
        {
            if (File.Exists(GetPath()))
                EditorUtility.RevealInFinder(GetPath());
            else
                EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        /// <summary>
        /// Saves ScriptableObject
        /// </summary>
        private void Save()
        {
            if (scriptableObject == null) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(GetPath());
            var json = JsonUtility.ToJson(scriptableObject);
            bf.Serialize(file, json);
            file.Close();
        }

        /// <summary>
        /// Loads ScriptableObject
        /// </summary>
        private void Load()
        {
            if (scriptableObject == null) return;

            if (File.Exists(GetPath()))
            {
                FileStream file = File.Open(GetPath(), FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), scriptableObject);
                file.Close();
            }
        }

        /// <summary>
        /// Returns persistent path for saving
        /// </summary>
        private string GetPath()
        {
            if (scriptableObject == null) return null;
            return Application.persistentDataPath + string.Format("/{0}.data", scriptableObject.name);
        }
    }
}
