using Unity.Netcode;
using UnityEngine;

public class PlayerChatRelay : NetworkBehaviour
{
    public static PlayerChatRelay localPlayer;

    void Start()
    {
        if (IsOwner)
        {
            localPlayer = this;
        }
    }

    public void SendMessageToServer(string msg)
    {
        SendMessageServerRpc(msg);
    }

    [ServerRpc]
    void SendMessageServerRpc(string msg, ServerRpcParams rpcParams = default)
    {
        ReceiveMessageClientRpc(msg, OwnerClientId);
    }

    [ClientRpc]
    void ReceiveMessageClientRpc(string msg, ulong senderId)
    {
        bool isMine = senderId == NetworkManager.Singleton.LocalClientId;
        ChatManager.instance.AddMessage(msg, isMine);
    }
}
