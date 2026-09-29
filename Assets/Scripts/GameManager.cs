using System.Collections;
using UnityEditor;
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

public class GameManager : MonoBehaviour
{
    private GameExitManager gameExitManager;
    private ServiceHub serviceHub;

    [SerializeField] public Scene Lev1;
    [SerializeField] public Scene Lev2;
    [SerializeField] public Scene Lev3;
    [SerializeField] public Scene Menu;
    public void Awake()//added to ensure level manager runs prior to event manager
    {
        // Cursor.SetCursor( BEAVERSAM-cursor );
        //currentActiveScene = Menu;
        //gameExitManager = Object.FindFirstObjectByType<GameExitManager>();// find the event manager
        //addAudio = Object.FindFirstObjectByType<AddAudio>();// find the audio  adder
        //alphaPOC_BossCombatController = Object.FindFirstObjectByType<AlphaPOC_BossCombatController>();// find and initalize
    }

   




}
