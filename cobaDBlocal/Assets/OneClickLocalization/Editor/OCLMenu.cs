using UnityEngine;
using UnityEditor;
using OneClickLocalization.Editor;
using OneClickLocalization.Core;
using System.IO;
using OneClickLocalization.Editor.Utils;

public class OCLMenu : MonoBehaviour
{

    private static readonly string documentationUrl = "http://www.redgirafegames.com/doc/OCL.html";
    
    [MenuItem("Window/One Click Localization/Setup %&l")]
    public static void ShowSetupWindow()
    {
        OCLSetupWindow.ShowWindow();
    }

    [MenuItem("Window/One Click Localization/Edit Localizations #%&l")]
    public static void ShowLocalizationWindow()
    {
        OCLLocalizationWindow window = OCLLocalizationWindow.ShowWindow();
        window.minSize = new Vector2(400, 200);
    }

    [MenuItem("Window/One Click Localization/Online Documentation")]
    public static void ShowDocumentation()
    {
        Application.OpenURL(documentationUrl);
    }
}
