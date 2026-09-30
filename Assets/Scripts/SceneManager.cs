
using UnityEngine;
using UnityEngine.SceneManagement;

#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Unity: Game Manager & Persistence
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations:
/// 
/// </summary>
#endregion

public class Scenemanager : MonoBehaviour
{

    [SerializeField] private Object Menu;
    [SerializeField] private Object Level1;
    [SerializeField] private Object Level2;
    [SerializeField] private Object Level3;
    public static int sceneIndex;
    public static int nextIndex;
    public GameManager gameManager;
    public void LoadLevelByIndex()
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }    
    }

    public void onLevel1()
    {
        if (Level1 != null)
        {
          SceneManager.LoadScene(1);
        }
    }

    public void onLevel2()
    {
        if (Level2 != null)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void onLevel3()
    {
        if (Level3 != null)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void onMenu()
    {
        if (Menu != null)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void onStart()
    {
        if (Level1 != null)
        {
            gameManager.onResetStats();
            onLevel1();
        }
    }
    public void onLoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevelByIndex();
    }


}

