using UnityEngine;

public class GameServices : MonoBehaviour
{
    public static PurchasingService PurchasingService { get; private set; }
    public static ItemsService ItemsService { get; private set; }
    public static CurrencyManager CurrencyManager { get; private set; }
    public static SavesManager SavesManager { get; private set; }
    public static ItemsConfig ItemsConfig { get; private set; }
    public static ShopConfig ShopConfig { get; private set; }
    public static EnemiesConfig EnemiesConfig { get; private set; }

    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private ShopConfig shopConfig;
    [SerializeField] private EnemiesConfig enemiesConfig;

    private void Awake()
    {
        PurchasingService = new PurchasingService();
        ItemsService = new ItemsService();
        CurrencyManager = new CurrencyManager();
        SavesManager = new SavesManager();

        ItemsConfig = itemsConfig;
        ShopConfig = shopConfig;
        EnemiesConfig = enemiesConfig;
    }
}
