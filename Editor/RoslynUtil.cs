using System.IO;
using UnityEditor;
using UnityEngine;

namespace SaintsConst.Editor
{
    public static class RoslynUtil
    {
        [InitializeOnLoadMethod]
        public static void OnLoad()
        {
            // string projectRootPath = Directory.GetCurrentDirectory();
            const string editorResFolder = "Assets/Editor Default Resources";
            if (!Directory.Exists(editorResFolder))
            {
                Debug.Log($"#Roslyn# create folder: {editorResFolder}");
                Directory.CreateDirectory(editorResFolder);
            }
            const string saintsFieldFolder = editorResFolder + "/SaintsConst";
            if (!Directory.Exists(saintsFieldFolder))
            {
                Debug.Log($"#Roslyn# create folder: {saintsFieldFolder}");
                Directory.CreateDirectory(saintsFieldFolder);
            }

            const string roslynConfigFile = saintsFieldFolder + "/Config.SaintsConstSourceGenerator.additionalfile";
            if (!File.Exists(roslynConfigFile))
            {
                Debug.Log($"#Roslyn# init for Config.SaintsConstSourceGenerator.additionalfile");
                File.WriteAllText(roslynConfigFile, "debug = 0\ndisabled = 0\n");
            }

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (string configLine in File.ReadAllLines(roslynConfigFile))
            {
                string[] split = configLine.Split('=');
                // ReSharper disable once InvertIf
                if (split.Length == 2 && split[0].Trim() == "disabled" && split[1].Trim() != "0")
                {
                    // Debug.LogWarning("#Roslyn# is disabled for SaintsField. Your field order might not be correct if you have SaintsEditor enabled");
                    return;
                }
            }

            const string roslynTempFileName = "Temp.SaintsConstSourceGenerator.additionalfile";
            const string roslynTempFile = saintsFieldFolder + "/" + roslynTempFileName;


            string projectRootPath = Directory.GetCurrentDirectory();
            string projectPath = projectRootPath.Replace("\\", "/");

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            string writeTempContent = $"project = {projectPath}\n";
            bool checkIgnore = true;
            if (File.Exists(roslynTempFile))
            {
                checkIgnore = false;

                string oldContent = File.ReadAllText(roslynTempFile);
                if (oldContent == writeTempContent)
                {
                    // Debug.Log($"#Roslyn# no update for {Repr(oldContent)} on path {roslynTempFile}");
                    writeTempContent = null;
                }
                else
                {
                    Debug.Log($"#Roslyn# generate config to {(writeTempContent)} from {(oldContent)} on path {roslynTempFile}");
                }
                // Debug.Log($"Init for Temp.SaintsFieldSourceParser.temporaryfile");
            }

            if (writeTempContent != null)
            {
                Debug.Log($"#Roslyn# set generate parse path into {roslynTempFile} with {(writeTempContent)}");
                File.WriteAllText(roslynTempFile, writeTempContent);
            }

            if (checkIgnore)
            {
                const string ignoreFile = saintsFieldFolder + "/.gitignore";
                Debug.Log($"#Roslyn# write ignore file: {ignoreFile}");
                File.WriteAllText(ignoreFile, $"{roslynTempFileName}\n{roslynTempFileName}.meta\n");
            }
        }
    }
}
