using UnityEngine;
using UnityEditor;

namespace CustomEditors
{
    public class LightingEditor
    {
        [MenuItem("Tools/Lighting/Find All Lights", false, 100)]
        public static void FindAllLights()
        {
            FindLightsOfType(LightmapBakeType.Realtime);
            FindLightsOfType(LightmapBakeType.Mixed);
            FindLightsOfType(LightmapBakeType.Baked);
        }

        [MenuItem("Tools/Lighting/Find All Realtime Lights", false, 1010)]
        public static void FindRealtimeLights()
        {
            FindLightsOfType(LightmapBakeType.Realtime);
        }

        [MenuItem("Tools/Lighting/Find All Mixed Lights", false, 1020)]
        public static void FindMixedLights()
        {
            FindLightsOfType(LightmapBakeType.Mixed);
        }

        [MenuItem("Tools/Lighting/Find All Baked Lights", false, 1030)]
        public static void FindBakedLights()
        {
            FindLightsOfType(LightmapBakeType.Baked);
        }

        /// <summary>
        /// Print all lights of one LightmapBakeType
        /// </summary>
        public static void FindLightsOfType(LightmapBakeType type)
        {
            object[] objs = Object.FindObjectsOfType(typeof(Light));
            foreach (Light light in objs)
            {
                if (light.lightmapBakeType == type)
                    Debug.Log(type.ToString() + " Light on " + light.gameObject, light);
            }
        }
    }
}
