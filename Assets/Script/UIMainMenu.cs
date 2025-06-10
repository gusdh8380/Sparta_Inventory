using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 메인 메뉴 UI를 제어하며, 캐릭터의 이름, 레벨, 골드, 경험치를 표시
/// </summary>

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Canvas main;

    [Header("[Button]")]
    [SerializeField] public Button StatusBtn;
    [SerializeField] public Button InventoryBtn;

    [Header("[CharacterInfo]")]
    [SerializeField] private TextMeshProUGUI NickName;
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI Gold;
    [SerializeField] private Image Expbar;
    [SerializeField] private TextMeshProUGUI ExpText;

    public void Refresh(Character ch)
    {
        NickName.text = ch.Name;                    
        Level.text = $"Lv {ch.Level}";
        Gold.text = $"{ch.Gold}";
        ExpText.text = $"{ch.CurrentExp}/12";
        Expbar.fillAmount = ch.CurrentExp / 12f;
    }


    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close() => gameObject.SetActive(false);


}
