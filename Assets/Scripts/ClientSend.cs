using UnityEngine;

namespace Assets.Scripts
{
    public class ClientSend : MonoBehaviour
    {
        #region Packets
        /// <summary>Lets the server know that the welcome message was received.</summary>
        public static void WelcomeReceived()
        {
            using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
            {
                _packet.Write(Client.instance.myId);
                _packet.Write(UIManager.instance.usernameField.text);

                SendUdpData(_packet);
            }
        }

        /// <summary>Sends player input to the server.</summary>
        /// <param name="_inputs"></param>
        public static void PlayerMovement(bool[] _inputs)
        {
            using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
            {
                _packet.Write(_inputs.Length);
                foreach (bool _input in _inputs)
                {
                    _packet.Write(_input);
                }
                _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);

                SendUdpData(_packet);
            }
        }
        #endregion

        private static void SendUdpData(Packet packet)
        {
            packet.WriteLength();
            Client.instance.Udp.SendData(packet);
        }
    }
}
