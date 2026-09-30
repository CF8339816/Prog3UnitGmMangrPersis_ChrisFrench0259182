using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

   [Header("System References")]
  
   public SceneManager sceneManager;


    private void Awake()
    {
    
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

}

