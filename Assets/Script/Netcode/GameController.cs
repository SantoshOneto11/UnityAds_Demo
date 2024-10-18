using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameController : NetworkBehaviour
{    
    private void Update()
    {
        if (IsServer)
        {
            List<string> connectedPlayerNames = new List<string>();

            foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
            {
                if (client.PlayerObject != null)
                {
                    string playerName = client.PlayerObject.GetComponent<NetworkObject>().OwnerClientId.ToString();
                    connectedPlayerNames.Add(playerName);
                }
            }

            Debug.Log("Connected Players: " + string.Join(", ", connectedPlayerNames[0]));
        }
    }
}
