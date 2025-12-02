using Unity.Netcode;
using UnityEngine;

public class AutoTestMessage : NetworkBehaviour
{
    void Update()
    {
        if (IsOwner && Input.GetKeyDown(KeyCode.F2))
        {
            PlayerChatRelay.localPlayer.SendMessageToServer("Test from Player");
        }
    }
}
