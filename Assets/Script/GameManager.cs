using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance {  get; private set; }

    [SerializeField] private Character player;

    //아이템 생성 테스트용 아이콘 & 버튼
    [SerializeField] private Sprite weaponIcon;
    [SerializeField] private Sprite armorIcon;
    [SerializeField] private Button gainexptest;
    [SerializeField] private Button gainitemtest2;

    public Character Player => player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    private void Start()
    {
        SetData();
        gainexptest.onClick.AddListener(() => Player.GainExp(1));
        gainitemtest2.onClick.AddListener(() => ItemInit());
    }

    public void SetData()
    {
        player = new Character("hyeon O", 120, 15, 8, 0.12f);
        Item weaponItem = new Item("Sword", weaponIcon, ItemType.Weapon, 10, 0, 1);
        Item armorItem = new Item("Shield", armorIcon, ItemType.Armor, 0, 10, 1);

        player.AddItem(weaponItem);
        player.AddItem(armorItem);


        UIManager.Instance.MainMenu.Refresh(player);
        UIManager.Instance.StatusUI.SetStatus(player);
       
    }

    /// <summary>
    /// 아이템 생성 함수, 테스트용
    /// </summary>
    public void ItemInit()
    {
        int randomInt = Random.Range(0, 100);
        Item item = new($"{randomInt}", armorIcon, ItemType.Weapon, 10, 5, 5);
        player.AddItem(item);
    }
}
