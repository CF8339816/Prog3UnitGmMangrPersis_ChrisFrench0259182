using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    private Scenemanager sceneManager;
    public TextMeshProUGUI textHealthText;
    public TextMeshProUGUI textInventoryAvaillabilityText;
    [SerializeField] private Slider HealthBar;
    [SerializeField] private Slider InventoryCapacity;
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
        sceneManager = Object.FindFirstObjectByType<Scenemanager>();
        sceneManager.onMenu();
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












