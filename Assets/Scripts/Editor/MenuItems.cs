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

    [MenuItem("Tools/Start Tutorial")]
    private static void StartTutorial()
    {
        if (EditorApplication.isPlaying)
        {
            TutorialManager.Instance.PlayTutorial();
            Debug.Log("Starting Tutorial....");
        }
        else
        {
            Debug.LogWarning("Cannot play Tutorial - Unity is not in Play Mode");
        }
    }
}