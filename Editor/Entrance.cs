using System.IO;
using UnityEditor;
using UnityEngine;

namespace SaintsConst.Editor
{
    public static class Entrance
    {
        public static readonly string[] ResourceSearchFolder =
        {
            "Assets/Editor Default Resources/SaintsConst",
            "Assets/SaintsConst/Editor/Editor Default Resources/SaintsConst", // unitypackage
            // this is readonly, put it to last so user  can easily override it
            "Packages/today.comes.saintsconst/Editor/Editor Default Resources/SaintsConst", // Unity UPM
        };

        public const string GenerateFolder = "Assets/SaintsConst.Generated";

        [InitializeOnLoadMethod]
        [MenuItem("Window/Saints/Refresh Saints Const")]
        private static void OnLoadWatch()
        {
            if(!Directory.Exists(GenerateFolder))
            {
                AssetDatabase.CreateFolder("Assets", "SaintsConst.Generated");
                foreach (string searchFolder in ResourceSearchFolder)
                {
                    string searchFile = $"{searchFolder}/today.comes.saintsconst.Generated.asmdef.txt";
                    if (File.Exists(searchFile))
                    {
                        File.Copy(searchFile, $"{GenerateFolder}/today.comes.saintsconst.Generated.asmdef");
                    }
                }
            }

            GenerateTags.OnLoadWatch();
            GenerateLayers.OnLoadWatch();
            GenerateSortingLayers.OnLoadWatch();
            GenerateRenderingLayers.OnLoadWatch();

            // WatchTagManagerAsset();
        }

        // private static void WatchTagManagerAsset()
        // {
        //     string oldContent = File.ReadAllText("ProjectSettings/TagManager.asset");
        //     EditorApplication.projectChanged += OnProjectChanged;
        // }
        //
        // private static void OnProjectChanged()
        // {
        //     Debug.Log("proj changed");
        // }
    }
}
