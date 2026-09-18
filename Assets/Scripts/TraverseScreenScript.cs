using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
public class TraverseScreenScript : MonoBehaviour
{
    public int sceneToLoad;

    void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 80.100, 30), "CurrentScene:" + (Application.loadedLevel + 1));
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 50.100, 40),"Load Scene" + (sceneToLoad +1)))
        {
            Application.LoadLevel(sceneToLoad);

            PlayerPrefs.SetInt("Helth",100);
            int x = PlayerPrefs.GetInt("Health");

        }


    }
}

