using UnityEngine;

public class DiceTableOpener : MonoBehaviour
{
    public GameObject diceTablePanel;   // 표 패널

    // 버튼에서 호출할 함수
    public void ShowDiceTable()
    {
        diceTablePanel.SetActive(true);
    }

    // 필요하면 닫기용
    public void HideDiceTable()
    {
        diceTablePanel.SetActive(false);
    }
}
