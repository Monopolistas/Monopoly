using System;
using System.Text;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using ExitGames.Client.Photon;

namespace Assets.Scripts.Network
{
    public class PlayerSerializer
    {

        public static GameStateMachine GameStateMachine;

        public static short Serialize(StreamBuffer outStream, object customObject)
        {
            Player player = (Player)customObject;

            int length;
            byte[] bytes;
            CopyToByteArray(player, out length, out bytes);
            outStream.Write(bytes, 0, length);

            return (short)length;
        }

        public static void CopyToByteArray(Player player, out int length, out byte[] bytes)
        {
            // Calculate byte array size
            short nameLength = (short)Encoding.UTF8.GetBytes(player.Name).Length;
            short colorNameLength = (short)Encoding.UTF8.GetBytes(player.PlayerColor.Name).Length;
            short intLength = sizeof(int);
            short shortLength = sizeof(short);
            length = intLength + shortLength + nameLength + intLength + shortLength + colorNameLength;

            // Instantiate byte array
            bytes = new byte[length];

            int index = 0;
            // Write Id
            Protocol.Serialize(player.Id, bytes, ref index);
            // Write name size
            Protocol.Serialize(nameLength, bytes, ref index);
            // Write name
            Array.Copy(Encoding.UTF8.GetBytes(player.Name), 0, bytes, index, nameLength);
            index += nameLength;
            // Write board slot id
            Protocol.Serialize(player.BoardSlot == null ? -1 : player.BoardSlot.Id, bytes, ref index);
            // Write color name size
            Protocol.Serialize(colorNameLength, bytes, ref index);
            // Write color name
            Array.Copy(Encoding.UTF8.GetBytes(player.PlayerColor.Name), 0, bytes, index, colorNameLength);
        }

        public static object Deserialize(StreamBuffer inStream, short length)
        {
            Player player = new Player();

            // Read byteArray
            int index = 0;
            byte[] byteArray = new byte[length];
            inStream.Read(byteArray, 0, length);

            int playerId;
            short nameLength;
            string name;
            int boardSlotId;
            short colorNameLength;
            string colorName;

            // Read Id
            Protocol.Deserialize(out playerId, byteArray, ref index);
            // Read name size
            Protocol.Deserialize(out nameLength, byteArray, ref index);
            // Read name
            name = Encoding.UTF8.GetString(byteArray, index, nameLength);
            index += nameLength;
            // Read Board Slot Id
            Protocol.Deserialize(out boardSlotId, byteArray, ref index);
            // Read color name size
            Protocol.Deserialize(out colorNameLength, byteArray, ref index);
            // Read name
            colorName = Encoding.UTF8.GetString(byteArray, index, colorNameLength);

            player.Id = playerId;
            player.Name = name;
            player.BoardSlot = boardSlotId == -1 ? null : GameStateMachine.Database.BoardSlotDictionary[boardSlotId];
            player.PlayerColor = PlayerColor.FindByName(colorName);

            return player;
        }

        public static int Length(Player player)
        {
            short nameLength = (short)Encoding.UTF8.GetBytes(player.Name).Length;
            short colorNameLength = (short)Encoding.UTF8.GetBytes(player.PlayerColor.Name).Length;
            short intLength = sizeof(int);
            short shortLength = sizeof(short);
            int length = intLength + shortLength + nameLength + intLength + shortLength + colorNameLength;
            return length;
        }

    }
}
