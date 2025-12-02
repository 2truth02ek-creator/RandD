using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DiceSelector : MonoBehaviour
{
    public Toggle d4Toggle;
    public Toggle d6Toggle;
    public Toggle d10Toggle;
    public Toggle d12Toggle;
    public Toggle d20Toggle;
    public Toggle d100Toggle;

    public ChatManager chatManager; // ★ 연결용

    public void RollSelectedDice()
    {
        List<string> resultParts = new List<string>();

        if (d4Toggle.isOn) resultParts.Add("D4: " + Roll(4));
        if (d6Toggle.isOn) resultParts.Add("D6: " + Roll(6));
        if (d10Toggle.isOn) resultParts.Add("D10: " + Roll(10));
        if (d12Toggle.isOn) resultParts.Add("D12: " + Roll(12));
        if (d20Toggle.isOn) resultParts.Add("D20: " + Roll(20));
        if (d100Toggle.isOn) resultParts.Add("D100: " + Roll(100));

        if (resultParts.Count == 0)
        {
            Debug.Log("[No dice selected]");
            return;
        }

        string finalMessage = "[" + string.Join(" / ", resultParts) + "]";

        // 콘솔 출력
        Debug.Log(finalMessage);

        // ★ 채팅창 말풍선으로 출력
        ChatManager.instance.SendExternalMessage(finalMessage);
    }

    int Roll(int sides)
    {
        return Random.Range(1, sides + 1);
    }
}
