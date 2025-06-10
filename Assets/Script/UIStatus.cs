using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 캐릭터의 스탯(공격력, 방어력, 체력, 치명타 확률)을 표시하는 UI 패널
/// </summary>
public class UIStatus : MonoBehaviour
{
    [SerializeField] private Canvas Status;
    [Header("[infoText]")]
    public TextMeshProUGUI Atk;
    public TextMeshProUGUI Bfs;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Critical;

    public Button ExitBtn;

    private Character Player => GameManager.Instance.Player;
    private void OnEnable()
    {
        if (GameManager.Instance == null || GameManager.Instance.Player == null) return;
        Player.OnStatChanged += Refresh;
        Refresh();
    }
    private void OnDisable()
    {
        Player.OnStatChanged -= Refresh;
    }
    public void Refresh()
    {
        Debug.Log($"{Player.Attack}");
        Atk.text = $"{Player.Attack}";
        Bfs.text = $"{Player.Defense}";
        Health.text = $"{Player.MaxHP}";
        Critical.text = $"{Player.CritChance}";
    }

    public void SetStatus(Character player)
    {
        Atk.text = $"{player.Attack}";
        Bfs.text = $"{player.Defense}";
        Health.text = $"{player.MaxHP}";
        Critical.text = $"{player.CritChance}";
    }
    public void Open()
    {
        Refresh();
        gameObject.SetActive(true);
    }
    public void Close() => gameObject.SetActive(false);
}
