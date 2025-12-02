using UnityEngine;
using TMPro;

public class ChatManager_backup : MonoBehaviour
{
    public TMP_InputField inputField;
    public Transform content;
    public GameObject chatBubblePrefab;

    public void SendMessageToChat()
    {
        string text = inputField.text;
        if (string.IsNullOrWhiteSpace(text))
            return;

        AddMessageToChat(text);

        inputField.text = "";
        inputField.ActivateInputField();
    }

    // ★ 외부에서 메시지 보낼 수 있는 함수
    public void AddMessageToChat(string msg)
    {
        GameObject bubble = Instantiate(chatBubblePrefab, content);

        TMP_Text bubbleText = bubble.transform.GetComponentInChildren<TMP_Text>();
        bubbleText.text = msg;
    }
}
