﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using OneClickLocalization.Core;

namespace OneClickLocalization.Editor.Utils
{
    static class DataUtils
    {
        /// <summary>
        /// Load a Setup Asset
        /// </summary>
        /// <returns></returns>
        public static bool LoadSetup()
        {
            string openPath = EditorUtility.OpenFilePanel("Load Setup Asset", Application.dataPath, "asset");

            if (openPath != null && !openPath.Equals(""))
            {
                string[] setupAssets = AssetDatabase.FindAssets("OCLSetup", new string[] { LocalizationSetup.setupPersistPath });
                if (setupAssets == null || setupAssets.Length > 0)
                {
                    if (!EditorUtility.DisplayDialog("Setup exists", "OCL already has a setup, loading a new one will replace it, are you sure you want lose current setup data?", "Yes, load and replace", "Nope!"))
                    {
                        return false;
                    }
                }
                string fromPath = "Assets" + openPath.Substring(Application.dataPath.Length);
                string toPath = LocalizationSetup.setupPersistPath + Path.DirectorySeparatorChar + LocalizationSetup.setupPersistName;
                bool copySuccess = AssetDatabase.CopyAsset(fromPath, toPath);
                if (!copySuccess)
                {
                    Debug.LogError("[Load Setup] Copy Setup Asset from <" + fromPath + "> to <" + toPath + "> failed");
                    return false;
                }
                else
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Save Current Setup Asset
        /// </summary>
        /// <returns></returns>
        public static bool SaveSetup()
        {
            string savePath = EditorUtility.SaveFilePanel("Save Setup Asset", Application.dataPath, "MySetup", "asset");

            if (savePath != null && !savePath.Equals(""))
            {
                if (savePath.IndexOf(Application.dataPath) != -1)
                {
                    string fromPath = LocalizationSetup.setupPersistPath + Path.DirectorySeparatorChar + LocalizationSetup.setupPersistName;
                    string toPath = "Assets" + savePath.Substring(Application.dataPath.Length);
                    bool copySuccess = AssetDatabase.CopyAsset(fromPath, toPath);
                    if (!copySuccess)
                    {
                        Debug.LogError("[Save Setup] Copy Setup Asset from <" + fromPath + "> to <" + toPath + "> failed");
                        return false;
                    }
                    else
                        return true;
                }
                else
                {
                    EditorUtility.DisplayDialog("Save error", "You must save your setup in the Assets Folder of your project", "OK");
                }
            }

            return false;

        }

        /// <summary>
        /// Create or replace an asset, depending on its existence.
        /// Code from http://answers.unity3d.com/questions/24929/assetdatabase-replacing-an-asset-but-leaving-refer.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asset"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T CreateOrReplaceAsset<T>(T asset, string path) where T : Object
        {
            T existingAsset = AssetDatabase.LoadAssetAtPath<T>(path);

            if (existingAsset == null)
            {
                AssetDatabase.CreateAsset(asset, path);
                existingAsset = asset;
            }
            else {
                EditorUtility.CopySerialized(asset, existingAsset);
            }

            return existingAsset;
        }

        /// <summary>
        /// Get all prefabs in given directory path recursively
        /// Result is updated in allPrefabs param.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="allPrefabs"></param>
        public static void GetAllPrefabsFromPath(string path, List<GameObject> allPrefabs)
        {
            GameObject[] newPrefabs = DataUtils.GetPrefabsInPath(path);
            if (newPrefabs != null && newPrefabs.Length > 0)
            {
                foreach (GameObject prefab in newPrefabs)
                {
                    allPrefabs.Add(prefab);
                }
            }

            string[] dirEntries = Directory.GetDirectories(path);

            if (dirEntries == null || dirEntries.Length == 0)
            {
                return;
            }
            else
            {
                foreach (string dir in dirEntries)
                {
                    GetAllPrefabsFromPath(dir, allPrefabs);
                }
            }


        }

        /// <summary>
        /// Returns Prefabs in the given directory path only
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static GameObject[] GetPrefabsInPath(string path)
        {

            ArrayList al = new ArrayList();
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                int index = fileName.LastIndexOfAny(new char[] { '/', '\\' });
                string localPath = path;
                localPath = "Assets" + localPath.Substring(Application.dataPath.Length);
                if (index > 0)
                {
                    string fileAssetName = fileName.Substring(index);
                    localPath += fileAssetName;
                }

                localPath = localPath.Replace("//", "/");
                Object obj = AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject));

                if (obj != null)
                    al.Add(obj);
            }
            GameObject[] result = new GameObject[al.Count];
            for (int i = 0; i < al.Count; i++)
                result[i] = (GameObject)al[i];

            return result;
        }

        /// <summary>
        /// splits a CSV row 
        /// Code from http://answers.unity3d.com/questions/144200/are-there-any-csv-reader-for-unity3d-without-needi.html
        /// </summary>
        /// <param name="line">The line to split</param>
        /// <returns></returns>
        public static string[] SplitCsvLine(string line, bool useSemiColonSeparator = false)
        {
            string pattern = null;
            if (useSemiColonSeparator)
            {
                pattern =@"
     # Match one value in valid CSV string.
     (?!\s*$)                                      # Don't match empty last value.
     \s*                                           # Strip whitespace before value.
     (?:                                           # Group for value alternatives.
       '(?<val>[^'\\]*(?:\\[\S\s][^'\\]*)*)'       # Either $1: Single quoted string,
     | ""(?<val>[^""\\]*(?:\\[\S\s][^""\\]*)*)""   # or $2: Double quoted string,
     | (?<val>[^;'""\s\\]*(?:\s+[^;'""\s\\]+)*)    # or $3: Non-comma, non-quote stuff.
     )                                             # End group of value alternatives.
     \s*                                           # Strip whitespace after value.
     (?:;|$)                                       # Field ends on comma or EOS.
     ";
            }
            else
            {
                pattern = @"
     # Match one value in valid CSV string.
     (?!\s*$)                                      # Don't match empty last value.
     \s*                                           # Strip whitespace before value.
     (?:                                           # Group for value alternatives.
       '(?<val>[^'\\]*(?:\\[\S\s][^'\\]*)*)'       # Either $1: Single quoted string,
     | ""(?<val>[^""\\]*(?:\\[\S\s][^""\\]*)*)""   # or $2: Double quoted string,
     | (?<val>[^,'""\s\\]*(?:\s+[^,'""\s\\]+)*)    # or $3: Non-comma, non-quote stuff.
     )                                             # End group of value alternatives.
     \s*                                           # Strip whitespace after value.
     (?:,|$)                                       # Field ends on comma or EOS.
     ";
            }
            MatchCollection matches = Regex.Matches(line, pattern, RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            string[] values =
                (from Match m in matches
                 select m.Groups[1].Value).ToArray();
            return values;
        }
    }
}
