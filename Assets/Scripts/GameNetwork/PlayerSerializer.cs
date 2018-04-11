using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSerializer
{

    public static GameStateMachine gameStateMachine;

    public static short Serialize(StreamBuffer outStream, object customObject)
    {
        Player player = (Player)customObject;

        short nameLength = (short)System.Text.Encoding.UTF8.GetBytes(player.Name).Length;
        short colorNameLength = (short)System.Text.Encoding.UTF8.GetBytes(player.PlayerColor.Name).Length;
        short intLength = sizeof(int);
        short shortLength = sizeof(short);
        int length = intLength + shortLength + nameLength + intLength + shortLength + colorNameLength;

        byte[] bytes = new byte[length];
        int index = 0;
        Protocol.Serialize(player.Id, bytes, ref index);
        Protocol.Serialize(nameLength, bytes, ref index);
        Array.Copy(System.Text.Encoding.UTF8.GetBytes(player.Name), 0, bytes, index, nameLength);
        index += nameLength;
        Protocol.Serialize(player.BoardSlot == null ? -1 : player.BoardSlot.Id, bytes, ref index);
        Protocol.Serialize(colorNameLength, bytes, ref index);
        Array.Copy(System.Text.Encoding.UTF8.GetBytes(player.PlayerColor.Name), 0, bytes, index, colorNameLength);
        outStream.Write(bytes, 0, length);

        return (short)length;
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
        name = System.Text.Encoding.UTF8.GetString(byteArray, index, nameLength);
        index += nameLength;
        // Read Board Slot Id
        Protocol.Deserialize(out boardSlotId, byteArray, ref index);
        // Read color name size
        Protocol.Deserialize(out colorNameLength, byteArray, ref index);
        // Read name
        colorName = System.Text.Encoding.UTF8.GetString(byteArray, index, colorNameLength);

        player.Id = playerId;
        player.Name = name;
        player.BoardSlot = boardSlotId == -1 ? null : gameStateMachine.Database.BoardSlotDictionary[boardSlotId];
        player.PlayerColor = PlayerColor.FindByName(colorName);

        return player;
    }

}
