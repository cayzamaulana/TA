﻿using UnityEngine;
using UnityEditor;
using System.Xml;
using OneClickLocalization.Core;
using OneClickLocalization.Core.Localization;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using OneClickLocalization.Editor.Utils;
using OneClickLocalization.Editor.Translator;

namespace OneClickLocalization.Editor
{
    /// <summary>
    /// Static class keeping Editor Data in one place.
    /// Exposes Import/Export methods.
    /// 
    /// Data is accessed from custom editor windows.
    /// 
    /// Images are initialized in static constructor, but <b>editorSetup</b> must be handled and kept updated by caller using <b>PersistSetup</b> and <b>LoadSetup</b> at the right time.
    /// </summary>
    public class DataManager
    {
        // Editor Images
        public static Texture closeIconTex;
        public static Texture setupIconTex;
        public static Texture editLocalizationsIconTex;
        public static Texture autoTranslateIconTex;
        public static Texture nullIconTex;
        private const string CLOSE_IMAGE_PATH = "Assets/OneClickLocalization/Editor/Textures/closeIcon.png";
        private const string SETUP_IMAGE_PATH = "Assets/OneClickLocalization/Editor/Textures/setupIcon.png";
        private const string EDIT_LOCALIZATIONS_IMAGE_PATH = "Assets/OneClickLocalization/Editor/Textures/editLocalizationsIcon.png";
        private const string AUTO_TRANSLATE_PATH = "Assets/OneClickLocalization/Editor/Textures/autoTranslateIcon.png";
        private const string NULL_PATH = "Assets/OneClickLocalization/Editor/Textures/nullIcon.png";

        // colors
        // 255,74,0
        public static Color mainColor = new Color(1f, .29f, 0f);
        
        public static Sprite defaultSprite;
        public static Texture defaultTexture;
        public static AudioClip defaultAudioClip;
        private const string DEFAULT_IMAGE_PATH = "OCL_defaults/imageDefault";
        private const string DEFAULT_AUDIOCLIP_PATH = "OCL_defaults/audioClipDefault";

        // EditorPrefs keys
        private const string PARSE_PREFABS_KEY = "OCL.parsePrefabs";
        private const string PARSE_PREFABS_PATH_KEY = "OCL.parsePrefabs.path";
        private const string PARSE_PREFABS_USE_INACTIVES_KEY = "OCL.parsePrefabs.useInactives";
        private const string PARSE_SCENES_KEY = "OCL.parseScenes";
        private const string PARSE_SCENES_SELECTED_KEY = "OCL.parseScenes.selected";
        private const string PARSE_SCENES_USE_INACTIVES_KEY = "OCL.parseScenes.useInactives";
        public static string PARSE_EXCLUDE_COMPS_KEY = "OCL.parse.includeComps";
        public static string PARSE_INCLUDE_COMPS_KEY = "OCL.parse.excludeComps";
        private const string ADD_ADAPTERS_KEY = "OCL.addAdapters";
        private const string EXTRACT_LOCALIZATION_DATA_KEY = "OCL.extractLocalizationData";
        private const string SUPPORTED_COMPS_SELECTED_KEY = "OCL.supportedComps.selected";
        private const string AUTO_TRANSLATE_KEY = "OCL.translator.auto";
        private const string TRANSLATOR_CLIENT_ID_KEY = "OCL.translator.clientId";
        private const string TRANSLATOR_CLIENT_SECRET_KEY = "OCL.translator.clientSecret";

        // Localization setup, loaded by OCL at runtime
        public static LocalizationSetup editorSetup;

        // Editor specific parameters
        public static bool parsePrefabs = true;
        public static string prefabsPath = "/";
        public static bool parseInactivesInPrefabs = true;
        public static bool parseScenes = true;
        public static int selectedScenes = -1;
        public static bool parseInactivesInScenes = true;
        public static bool addAdapters = true;
        public static bool extractLocalizationData = true;
        // select only strings by default
        public static int selectedSupportedTypes = 1;
        public static Type[] supportedCompsList = { typeof(string), typeof(Texture), typeof(Sprite), typeof(AudioClip) };
        public static string parseExcludeCompsDefault = "";
        public static string parseExcludeComps = parseExcludeCompsDefault;
        public static string parseIncludeCompsDefault = "UnityEngine.UI.Text,UnityEngine.UI.Image,UnityEngine.UI.RawImage,UnityEngine.GUIText,UnityEngine.TextMesh,UnityEngine.AudioSource,UnityEngine.GUITexture";
        [SerializeField]
        public static List<string> listTest = new List<string>();
        public static string parseIncludeComps = parseIncludeCompsDefault;

        public static string includeExcludeCompsSeparator = ",";

        // Translator
        public static MicrosoftTranslator translator;
        public static string defaultTranslatorClientId = "OCLDefaultUser";
        public static string translatorClientId = defaultTranslatorClientId;
        public static string defaultTranslatorClientSecret = "R10rPY24EYeJKtWeSnMCwGxRe3HYsa/UNxFipr1xw0w=";
        public static string translatorClientSecret = defaultTranslatorClientSecret;

        static DataManager()
        {
            closeIconTex = (Texture)AssetDatabase.LoadAssetAtPath(CLOSE_IMAGE_PATH, typeof(Texture));
            setupIconTex = (Texture)AssetDatabase.LoadAssetAtPath(SETUP_IMAGE_PATH, typeof(Texture));
            editLocalizationsIconTex = (Texture)AssetDatabase.LoadAssetAtPath(EDIT_LOCALIZATIONS_IMAGE_PATH, typeof(Texture));
            autoTranslateIconTex = (Texture)AssetDatabase.LoadAssetAtPath(AUTO_TRANSLATE_PATH, typeof(Texture));
            nullIconTex = (Texture)AssetDatabase.LoadAssetAtPath(NULL_PATH, typeof(Texture));
            //defaultSprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            defaultSprite = Resources.Load<Sprite>(DEFAULT_IMAGE_PATH);
            defaultTexture = Resources.Load<Texture>(DEFAULT_IMAGE_PATH); 
            defaultAudioClip = Resources.Load<AudioClip>(DEFAULT_AUDIOCLIP_PATH);

            translator = new MicrosoftTranslator(translatorClientId, translatorClientSecret);
        }


        /// <summary>
        /// Persist setup asset on disk
        /// </summary>
        public static void PersistSetup()
        {
            editorSetup = DataUtils.CreateOrReplaceAsset(editorSetup, LocalizationSetup.setupPersistPath + Path.DirectorySeparatorChar + LocalizationSetup.setupPersistName);
            EditorUtility.SetDirty(editorSetup);
            foreach (ILocalization loc in editorSetup.allLocalizations)
            {
                if (loc is StringLocalization)
                    EditorUtility.SetDirty((StringLocalization)loc);
            }
        }

        /// <summary>
        /// Load setup asset from disk
        /// </summary>
        public static void LoadSetup()
        {
            // Load only one time
            if (editorSetup == null)
            {
                editorSetup = AssetDatabase.LoadAssetAtPath<LocalizationSetup>(LocalizationSetup.setupPersistPath + Path.DirectorySeparatorChar + LocalizationSetup.setupPersistName);
                // no persisted setup
                if (editorSetup == null)
                {
                    // create new one
                    editorSetup = ScriptableObject.CreateInstance<LocalizationSetup>();
                    PersistSetup();
                }
                // found existing setup, get its subassets
                editorSetup.LoadSubAssets(false);
            }
        }
        
        /// <summary>
        /// Saves data specific to the editor
        /// </summary>
        public static void SaveEditorPrefs()
        {
            EditorPrefs.SetBool(PARSE_PREFABS_KEY, parsePrefabs);
            EditorPrefs.SetString(PARSE_PREFABS_PATH_KEY, prefabsPath);
            EditorPrefs.SetBool(PARSE_PREFABS_USE_INACTIVES_KEY, parseInactivesInPrefabs);
            EditorPrefs.SetBool(PARSE_SCENES_KEY, parseScenes);
            EditorPrefs.SetInt(PARSE_SCENES_SELECTED_KEY, selectedScenes);
            EditorPrefs.SetBool(PARSE_SCENES_USE_INACTIVES_KEY, parseInactivesInScenes);
            EditorPrefs.SetBool(ADD_ADAPTERS_KEY, addAdapters);
            EditorPrefs.SetBool(EXTRACT_LOCALIZATION_DATA_KEY, extractLocalizationData);
            EditorPrefs.SetInt(SUPPORTED_COMPS_SELECTED_KEY, selectedSupportedTypes);
            EditorPrefs.SetString(PARSE_INCLUDE_COMPS_KEY, parseIncludeComps);
            EditorPrefs.SetString(PARSE_EXCLUDE_COMPS_KEY, parseExcludeComps);
            EditorPrefs.SetString(TRANSLATOR_CLIENT_ID_KEY, translatorClientId);
            EditorPrefs.SetString(TRANSLATOR_CLIENT_SECRET_KEY, translatorClientSecret);
        }
        /// <summary>
        /// Load data specific to the editor
        /// </summary>
        public static void LoadEditorPrefs()
        {
            if (EditorPrefs.HasKey(PARSE_PREFABS_KEY))
                parsePrefabs = EditorPrefs.GetBool(PARSE_PREFABS_KEY);
            if (EditorPrefs.HasKey(PARSE_PREFABS_PATH_KEY))
                prefabsPath = EditorPrefs.GetString(PARSE_PREFABS_PATH_KEY);
            if (EditorPrefs.HasKey(PARSE_PREFABS_USE_INACTIVES_KEY))
                parseInactivesInPrefabs = EditorPrefs.GetBool(PARSE_PREFABS_USE_INACTIVES_KEY);
            if (EditorPrefs.HasKey(PARSE_SCENES_KEY))
                parseScenes = EditorPrefs.GetBool(PARSE_SCENES_KEY);
            if (EditorPrefs.HasKey(PARSE_SCENES_SELECTED_KEY))
                selectedScenes = EditorPrefs.GetInt(PARSE_SCENES_SELECTED_KEY);
            if (EditorPrefs.HasKey(PARSE_SCENES_USE_INACTIVES_KEY))
                parseInactivesInScenes= EditorPrefs.GetBool(PARSE_SCENES_USE_INACTIVES_KEY);
            if (EditorPrefs.HasKey(ADD_ADAPTERS_KEY))
                addAdapters = EditorPrefs.GetBool(ADD_ADAPTERS_KEY);
            if (EditorPrefs.HasKey(EXTRACT_LOCALIZATION_DATA_KEY))
                extractLocalizationData = EditorPrefs.GetBool(EXTRACT_LOCALIZATION_DATA_KEY);
            if (EditorPrefs.HasKey(SUPPORTED_COMPS_SELECTED_KEY))
                selectedSupportedTypes = EditorPrefs.GetInt(SUPPORTED_COMPS_SELECTED_KEY);
            if (EditorPrefs.HasKey(PARSE_INCLUDE_COMPS_KEY))
                parseIncludeComps= EditorPrefs.GetString(PARSE_INCLUDE_COMPS_KEY);
            if (EditorPrefs.HasKey(PARSE_EXCLUDE_COMPS_KEY))
                parseExcludeComps= EditorPrefs.GetString(PARSE_EXCLUDE_COMPS_KEY);
            if (EditorPrefs.HasKey(TRANSLATOR_CLIENT_ID_KEY))
                translatorClientId = EditorPrefs.GetString(TRANSLATOR_CLIENT_ID_KEY);
            if (EditorPrefs.HasKey(TRANSLATOR_CLIENT_SECRET_KEY))
                translatorClientSecret = EditorPrefs.GetString(TRANSLATOR_CLIENT_SECRET_KEY);
            translator.SetCredentials(translatorClientId, translatorClientSecret);
        }


        internal static void ResetEditorPrefs()
        {
            EditorPrefs.DeleteKey(PARSE_PREFABS_KEY);
            parsePrefabs = true;
            EditorPrefs.DeleteKey(PARSE_PREFABS_PATH_KEY);
            prefabsPath = "/";
            EditorPrefs.DeleteKey(PARSE_PREFABS_USE_INACTIVES_KEY);
            parseInactivesInPrefabs = true;
            EditorPrefs.DeleteKey(PARSE_SCENES_KEY);
            parseScenes = true;
            EditorPrefs.DeleteKey(PARSE_SCENES_SELECTED_KEY);
            selectedScenes = -1;
            EditorPrefs.DeleteKey(PARSE_SCENES_USE_INACTIVES_KEY);
            parseInactivesInScenes = true;
            EditorPrefs.DeleteKey(ADD_ADAPTERS_KEY);
            addAdapters = true;
            EditorPrefs.DeleteKey(EXTRACT_LOCALIZATION_DATA_KEY);
            extractLocalizationData = true;
            EditorPrefs.DeleteKey(SUPPORTED_COMPS_SELECTED_KEY);
            selectedSupportedTypes = 1;
            EditorPrefs.DeleteKey(PARSE_INCLUDE_COMPS_KEY);
            parseIncludeComps = parseIncludeCompsDefault;
            EditorPrefs.DeleteKey(PARSE_EXCLUDE_COMPS_KEY);
            parseExcludeComps = parseExcludeCompsDefault;
            EditorPrefs.DeleteKey(translatorClientId);
            translatorClientId = defaultTranslatorClientId;
            EditorPrefs.DeleteKey(translatorClientSecret);
            translatorClientSecret = defaultTranslatorClientSecret;
        }
        
        public static bool IsTranslatorDefaultCredentials()
        {
            return translatorClientId.Equals(defaultTranslatorClientId) && translatorClientSecret.Equals(defaultTranslatorClientSecret);
        }

        /// <summary>
        /// Export localizations to xml.
        /// </summary>
        /// <param name="languages">If not null, only given languages are exported. If null all languages are exported.</param>
        /// <returns></returns>
        public static bool ExportToXml(SystemLanguage[] languages = null)
        {
            bool res = true;

            XmlDocument exportDoc = new XmlDocument();
            XmlNode docNode = exportDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            exportDoc.AppendChild(docNode);

            XmlNode rootNode = exportDoc.CreateElement("localization");
            exportDoc.AppendChild(rootNode);
            XmlNode itemsNode = exportDoc.CreateElement("strings");
            rootNode.AppendChild(itemsNode);


            string formatedStringId = null;
            object localizationValue = null;

            foreach (string stringId in editorSetup.GetIds<string>())
            {
                // check if already exists
                if (itemsNode.Attributes[stringId] == null)
                {
                    XmlNode itemNode = exportDoc.CreateElement("string");
                    itemsNode.AppendChild(itemNode);
                    XmlAttribute stringIdAtt = exportDoc.CreateAttribute("stringId");

                    formatedStringId = FormatStringForCSVExport(stringId);
                    stringIdAtt.Value = formatedStringId;
                    itemNode.Attributes.Append(stringIdAtt);
                    
                    foreach (SystemLanguage lang in editorSetup.languages)
                    {
                        bool languageHandled = IsLanguageHandled(languages, lang);

                        if (languageHandled)
                        {

                            XmlNode valueNode = exportDoc.CreateElement("value");
                            XmlAttribute valueLang = exportDoc.CreateAttribute("lang");
                            valueLang.Value = lang.ToString();
                            localizationValue = editorSetup.GetLocalization(stringId, lang);
                            if (localizationValue != null)
                            {
                                //formatedLocalizationValue = FormatStringToExport(localizationValue.ToString());
                                valueNode.InnerText = (string)localizationValue;
                                valueNode.Attributes.Append(valueLang);
                                itemNode.AppendChild(valueNode);
                            }
                        }
                    }

                }

            }
            string savePath = EditorUtility.SaveFilePanel("Save XML Export", Application.dataPath, "OCL_export_" + System.DateTime.Now.Ticks + ".xml", "xml");
            if (savePath != null && !savePath.Equals(""))
            {
                exportDoc.Save(savePath);
            }
            else
            {
                res = false;
            }

            return res;
        }
        
        /// <summary>
        /// Import localizations from xml.
        /// </summary>
        /// <param name="languages">If not null, only given languages are imported. If null all languages are imported.</param>
        /// <param name="overrideData">If true, existing localizations will have there value overriden by the xml import</param>
        /// <returns></returns>
        public static List<string> ImportFromXml(SystemLanguage[] languages = null, bool overrideData = false)
        {
            List<string> res = new List<string>();

            if (editorSetup == null)
            {
                return res;
            }
            try
            {
                List<string> currentStringIds = editorSetup.GetIds<string>();

                string importPath = EditorUtility.OpenFilePanel("Choose XML File", Application.dataPath, "xml");

                XmlDocument importXml = new XmlDocument();
                importXml.Load(importPath);

                XmlNode root = importXml.DocumentElement;
                XmlNode itemsNode = root["strings"];

                string formatedStringId = null;
                string stringId = null;
                string localizationValue = null;

                foreach (XmlNode itemNode in itemsNode.ChildNodes)
                {
                    formatedStringId = itemNode.Attributes["stringId"].Value;
                    stringId = FormatStringForCSVImport(formatedStringId);

                    if (!currentStringIds.Contains(stringId, StringComparer.OrdinalIgnoreCase)
                        && !res.Contains(stringId, StringComparer.OrdinalIgnoreCase))
                    {
                        editorSetup.AddId(stringId);
                        //Debug.Log("Add new StringId [" + stringId + "]");
                    }

                    foreach (XmlNode langNode in itemNode.ChildNodes)
                    {
                        string lang = langNode.Attributes["lang"].Value;
                        localizationValue = langNode.InnerText;

                        SystemLanguage langEnum = (SystemLanguage)System.Enum.Parse(typeof(SystemLanguage), lang, true);
                        ImportLocalization(overrideData, stringId, localizationValue, langEnum);

                    }
                }
            }
            catch (Exception e)
            {
                res = new List<string>();
                Debug.LogError("Error during XML import : " + e.Message);
            }

            return res;
        }
        
        public static bool ExportToCSV(SystemLanguage[] languages = null, bool useSemiColonSeparator = false)
        {
            bool res = true;

            char csvSeparator = (useSemiColonSeparator ? ';' : ',');

            StringBuilder csv = new StringBuilder();

            List<SystemLanguage> headerLanguages = new List<SystemLanguage>();

            // Headers
            csv.Append("StringId");
            for (int i = 0; i < editorSetup.languages.Count; i++)
            {
                SystemLanguage lang = editorSetup.languages[i];
                bool languageHandled = IsLanguageHandled(languages, lang);

                if (languageHandled)
                {
                    headerLanguages.Add(lang);
                    csv.Append(csvSeparator);
                    csv.Append(lang);
                }
            }

            csv.AppendLine();

            string formatedStringId = null;
            object localization = null;
            string formatedLocalization = null;
            // Localizations
            foreach (string stringId in editorSetup.GetIds<string>())
            {
                // Line return handle
                formatedStringId = FormatStringForCSVExport(stringId);

                csv.Append("\"" + formatedStringId + "\"");

                for (int i=0; i<headerLanguages.Count; i++)
                {
                    SystemLanguage headerLang = headerLanguages[i];

                    localization = editorSetup.GetLocalization(stringId, headerLang);
                    if (localization != null)
                    {
                        // Line return handle
                        formatedLocalization = FormatStringForCSVExport((string)localization);
                        formatedLocalization = "\"" + formatedLocalization + "\"";
                    }
                    else
                    {
                        formatedLocalization = StringLocalization.NULL_SERIALIZATION_VALUE;
                    }
                    csv.Append(csvSeparator);
                    csv.Append(formatedLocalization);

                }

                csv.AppendLine();
                
            }

            string savePath = EditorUtility.SaveFilePanel("Save CSV Export", Application.dataPath, "OCL_export_" + System.DateTime.Now.Ticks + ".csv", "csv");
            if (savePath != null && !savePath.Equals(""))
            {
                System.IO.File.WriteAllText(savePath, csv.ToString());
            }
            else
            {
                res = false;
            }

            return res;
        }

        /// <summary>
        /// Import localizations from CSV.
        /// </summary>
        /// <param name="languages">If not null, only given languages are imported. If null all languages are imported.</param>
        /// <param name="overrideData">If true, existing localizations will have there value overriden by the xml import</param>
        /// <returns>ids added</returns>
        public static List<string> ImportFromCSV(SystemLanguage[] languages = null, bool overrideData = false)
        {
            List<string> res = new List<string>();

            if (editorSetup == null)
            {
                return res;
            }
            try
            {
                List<string> currentStringIds = editorSetup.GetIds<string>();

                string importPath = EditorUtility.OpenFilePanel("Choose CSV File", Application.dataPath, "csv");
                if(importPath == null || importPath.Equals(""))
                {
                    return res;
                }
                EditorUtility.DisplayProgressBar("CSV import", "Start import from " + importPath, 0.0f);

                int counter = 0;
                string line;

                SystemLanguage[] headers = null;

                int lines = File.ReadAllLines(importPath).Length;

                System.IO.StreamReader file = new System.IO.StreamReader(importPath);
                while ((line = file.ReadLine()) != null)
                {
                    string[] lineValues = DataUtils.SplitCsvLine(line);
                    if (counter == 0)
                    {
                        EditorUtility.DisplayProgressBar("CSV import", "Import languages headers", 0.0f);
                        headers = new SystemLanguage[lineValues.Length];
                        for (int i = 0; i < lineValues.Length; i++)
                        {
                            if (i == 0)
                            {
                                // string id column header
                                continue;
                            }
                            string header = lineValues[i];
                            SystemLanguage langEnum = (SystemLanguage)System.Enum.Parse(typeof(SystemLanguage), header, true);
                            headers[i] = langEnum;

                        }
                    }
                    else
                    {
                        float progress = (float)counter / (float)lines;
                        EditorUtility.DisplayProgressBar("CSV import", "Import Localization " + counter + "/" + lines, progress);

                        string formatedStringId = null;
                        string stringId = null;
                        string formatedLocalizationValue = null;
                        string localizationValue = null;
                        SystemLanguage langEnum = SystemLanguage.Unknown;

                        for (int i = 0; i < lineValues.Length; i++)
                        {
                            if (i == 0)
                            {
                                // string id column header
                                formatedStringId = lineValues[i];
                                stringId = FormatStringForCSVImport(formatedStringId);

                                if (!currentStringIds.Contains(stringId, StringComparer.OrdinalIgnoreCase) 
                                    && !res.Contains(stringId, StringComparer.OrdinalIgnoreCase))
                                {
                                    res.Add(stringId);
                                    editorSetup.AddId(stringId);
                                    //Debug.Log("Add new StringId [" + stringId + "]");
                                }
                            }
                            else
                            {
                                langEnum = headers[i];
                                formatedLocalizationValue = lineValues[i];
                                localizationValue = FormatStringForCSVImport(formatedLocalizationValue);

                                if (localizationValue.Equals(StringLocalization.NULL_SERIALIZATION_VALUE))
                                    localizationValue = null;
                                ImportLocalization(overrideData, stringId, localizationValue, langEnum);
                            }
                        }

                    }
                    counter++;
                }

                file.Close();
            }
            catch (Exception e)
            {
                res = new List<string>();
                Debug.LogError("Error during CSV import : " + e.Message);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
            return res;
        }

        /// <summary>
        /// Import new localization
        /// </summary>
        /// <param name="overrideData"></param>
        /// <param name="stringId"></param>
        /// <param name="localizationValue"></param>
        /// <param name="langEnum"></param>
        private static void ImportLocalization(bool overrideData, string stringId, string localizationValue, SystemLanguage langEnum)
        {
            if (editorSetup.languages.Contains(langEnum) 
                && (overrideData || editorSetup.GetLocalization(stringId, langEnum) == null))
            {
                //Debug.Log("[" + stringId + "] " + (doOverride ? "Override" : "Add") + " localization <" + langEnum + "> <" + localizationValue + ">");
                editorSetup.SetLocalization(stringId, langEnum, localizationValue);
            }
        }
        
        private static string FormatStringForCSVImport(string formatedStr)
        {
            if (formatedStr == null)
                return null;
            formatedStr = formatedStr.Replace("\\n", "\n");
            return formatedStr;
        }

        private static string FormatStringForCSVExport(string str)
        {
            if (str == null)
                return null;
            str = str.Replace("\n", "\\n");
            return str;
        }

        /// <summary>
        /// Test if a given language can be used, comparing given languages and setup languages
        /// </summary>
        /// <param name="languages"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        private static bool IsLanguageHandled(SystemLanguage[] languages, SystemLanguage lang)
        {
            bool languageHandled = false;
            if (languages != null)
            {
                foreach (SystemLanguage language in languages)
                {
                    if (language.Equals(lang))
                    {
                        languageHandled = true;
                        break;
                    }
                }

            }
            else
            {
                languageHandled = true;
            }

            return languageHandled;
        }
    }

}