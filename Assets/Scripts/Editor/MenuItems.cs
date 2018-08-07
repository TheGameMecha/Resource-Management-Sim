using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuItems
{
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player Prefs cleared!");
    }

    [MenuItem("Tools/Clear SaveData")]
    private static void ClearSavaData()
    {
        File.Delete(Application.persistentDataPath + "/savedGames.gd");
        Debug.Log("Save Data cleared!");
    }
}