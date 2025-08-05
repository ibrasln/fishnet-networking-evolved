using FishNet;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button createRoomButton;
    [SerializeField] private Button joinRoomButton;
    [SerializeField] private TMP_InputField ipInputField;
    [SerializeField] private TextMeshProUGUI ipDisplayText;
    [SerializeField] private TextMeshProUGUI statusText;

    private void OnEnable()
    {
        createRoomButton.onClick.AddListener(CreateRoom);
        joinRoomButton.onClick.AddListener(JoinRoom);
    }

    private void OnDisable()
    {
        createRoomButton.onClick.RemoveListener(CreateRoom);
        joinRoomButton.onClick.RemoveListener(JoinRoom);
    }

    private void CreateRoom()
    {
        // It gets the local ip address..
        string ip = HelperUtilities.GetLocalIPAddress();

        // ..For now, we are going to use a custom ip.
        //string ip = "192.168.0.1";

        ipDisplayText.text = $"IP: {ip}";
        statusText.text = "Hosting room...";

        InstanceFinder.ServerManager.StartConnection();
        InstanceFinder.ClientManager.StartConnection(); // Host also joins the game.
    }

    private void JoinRoom()
    {
        string ip = ipInputField.text;
        InstanceFinder.NetworkManager.TransportManager.Transport.SetClientAddress(ip);
        InstanceFinder.ClientManager.StartConnection();
        statusText.text = $"Joining room {ip}...";    
    }
}
