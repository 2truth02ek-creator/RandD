using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public static ChatManager instance;

    public TMP_InputField inputField;
    public Transform content;
    public GameObject chatBubblePrefab;

    private void Awake()
    {
        instance = this;
    }

    public void SendMessageToChat()
    {
        string text = inputField.text;
        if (string.IsNullOrWhiteSpace(text))
            return;

        // 로컬 표시 (내 메시지)
        //AddMessage(text, true);

        // 네트워크로 보내기
        PlayerChatRelay.localPlayer.SendMessageToServer(text);

        inputField.text = "";
        inputField.ActivateInputField();
    }

    // ★ 네트워크에서도, 로컬에서도 공통으로 쓰는 함수
    public void AddMessage(string msg, bool isMine)
    {
        GameObject bubble = Instantiate(chatBubblePrefab, content);

        TMP_Text bubbleText = bubble.transform.GetComponentInChildren<TMP_Text>();
        bubbleText.text = msg;

        bubbleText.alignment = isMine
           ? TextAlignmentOptions.MidlineRight
           : TextAlignmentOptions.MidlineLeft;

        // 필요하면 이후에 좌/우 정렬 추가
    }

    // ★ DiceSelector 같은 외부 클래스가 사용할 수 있는 이전 방식
    public void AddMessageToChat(string msg)
    {
        AddMessage(msg, true);
    }
    public void SendExternalMessage(string msg)
    {
        PlayerChatRelay.localPlayer.SendMessageToServer(msg);
    }
}
