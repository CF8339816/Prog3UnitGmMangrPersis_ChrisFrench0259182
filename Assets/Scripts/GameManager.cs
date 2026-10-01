using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
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
    private GameManager gameManager;
    private SceneManager sceneManager;
    public TextMeshProUGUI textHealthText;
    public TextMeshProUGUI textInventoryAvaillabilityText;

    [SerializeField] private Slider HealthBar;
    [SerializeField] private Slider InventoryCapacity;

    [SerializeField] public Scene Lev1;
    [SerializeField] public Scene Lev2;
    [SerializeField] public Scene Lev3;
    [SerializeField] public Scene Menu;

    public int HealthBarMax = 100;
    private int HealthBarMin = 0;
    [SerializeField] public int InventoryBarMax = 24;
    private int InventoryBarMin = 0;
    public int InventoryslotsUsed = 0;
    private int InventorySpaceAvailable;
    [SerializeField] public int healingDone= 12 ;
    [SerializeField] public int DamageTaken= 21;
    public int currentHealth;
    private int currentHealthPercentage;
    private int healtBarOutput;
    [SerializeField] public int maxHealth;


    public void Awake()//added to ensure level manager runs prior to event manager
    {
        gameManager= Object.FindFirstObjectByType<GameManager>();
        serviceHub = Object.FindFirstObjectByType<ServiceHub>();
        gameExitManager = Object.FindFirstObjectByType<GameExitManager>();
      //  sceneManager = Object.FindFirstObjectByType<SceneManager>();

        if (Menu != null)
        {
            SceneManager.LoadScene(0);
        }

        onResetStats();
    }
    private void Update()
    {
        UpdateBagSpace();
        UpdateHealthBar();

    }
    public void UpdateBagSpace()
    {
        InventorySpaceAvailable = InventoryBarMax - InventoryslotsUsed;
        InventoryCapacity.value = InventoryslotsUsed;
        textInventoryAvaillabilityText.text = "Slots available" + InventorySpaceAvailable.ToString() + "\nInventory used: " + InventoryslotsUsed.ToString() + "/" + InventoryBarMax.ToString();
    }

    public void UpdateHealthBar()
    {
        healtBarOutput = currentHealthPercentage;
        HealthBar.value = healtBarOutput;
        textHealthText.text = "Health %: " + currentHealthPercentage.ToString() + "\nHealth: " + currentHealth.ToString()  +"/" + maxHealth.ToString();

    }

    public void onTakeDamage()
    {
        currentHealth = -DamageTaken;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        currentHealthPercentage =((currentHealth/ maxHealth)*100);
    }
   
    public void onTakeHealing()
    {        
        currentHealth = +healingDone;
       if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }   
        currentHealthPercentage= ((currentHealth / maxHealth) * 100); 
    }


    public void onAddItem()
    {
        InventoryslotsUsed++;
    }

    public void onRemoveItem()
    {
        InventoryslotsUsed--;
    }


    public void onResetStats()
    {
        currentHealth = maxHealth;
        InventoryslotsUsed = 0;

        HealthBar.value = healtBarOutput;
        InventoryCapacity.value = InventoryslotsUsed;
    }




}












