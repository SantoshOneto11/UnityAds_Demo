using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using TMPro;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

public class SetUpLAN : MonoBehaviour
{
    private PlayerControl pc;
    private bool pcAssigned;

    [SerializeField] TextMeshProUGUI ipAddressText;
    [SerializeField] TMP_InputField ip;

    [SerializeField] string ipAddress;
    [SerializeField] UnityTransport transport;

    void Start()
    {
        ipAddress = "0.0.0.0";
        SetIpAddress(); // Set the Ip to the above address
        pcAssigned = false;
        InvokeRepeating("assignPlayerController", 0.1f, 0.1f);
    }

    // To Host a game
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        GetLocalIPAddress();
    }

    // To Join a game
    public void StartClient()
    {
        ipAddress = ip.text;
        SetIpAddress();
        ipAddressText.text = ipAddress;
        NetworkManager.Singleton.StartClient();
    }

    /* Gets the Ip Address of your connected network and
	shows on the screen in order to let other players join
	by inputing that Ip in the input field */
    // ONLY FOR HOST SIDE 
    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipAddressText.text = ip.ToString();
                ipAddress = ip.ToString();
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }

    /* Sets the Ip Address of the Connection Data in Unity Transport
	to the Ip Address which was input in the Input Field */
    // ONLY FOR CLIENT SIDE
    public void SetIpAddress()
    {
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ipAddress;
    }

    public void GetConnectedClients()
    {
        List<string> connectedClients = new List<string>();
        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            if(client.PlayerObject != null)
            {
                string player = client.PlayerObject.name.ToString();
                connectedClients.Add(player);

                Debug.Log(connectedClients[connectedClients.Count-1] + " "+ NetworkManager.Singleton.ConnectedClientsList.Count);
            }
        }
    }


    // Assigns the player to this script when player is loaded
    private void assignPlayerController()
    {
        if (pc == null)
        {
            pc = FindObjectOfType<PlayerControl>();
        }
        else if (pc == FindObjectOfType<PlayerControl>())
        {
            pcAssigned = true;
            CancelInvoke();
        }
    }
}
