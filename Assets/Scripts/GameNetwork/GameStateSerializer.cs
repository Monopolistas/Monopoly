using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSerializer
{

    public static GameStateMachine gameStateMachine;

    public static short Serialize(StreamBuffer outStream, object customObject)
    {
        GameState gameState = (GameState)customObject;

        Player playerOnTurn = gameState.PlayerOnTurn;

        int playerOnTurnLength;
        byte[] playerOnTurnBytes;
        PlayerSerializer.CopyToByteArray(playerOnTurn, out playerOnTurnLength, out playerOnTurnBytes);

        Player[] players = gameState.Players;

        int playersLength = 0;
        short[] playersLengthArray = new short[players.Length];
        int index = 0;

        foreach (Player p in players)
        {
            short pLength = (short)PlayerSerializer.Length(p);
            playersLengthArray[index] = pLength;
            playersLength += pLength;
            index++;
        }

        byte[] playersBytes = new byte[playersLength];

        index = 0;
        foreach (Player p in players)
        {
            int length;
            byte[] bytes;
            PlayerSerializer.CopyToByteArray(p, out length, out bytes);
            Array.Copy(bytes, 0, playersBytes, index, length);
            index += length;
        }

        int finalLength = sizeof(short) + playerOnTurnLength + sizeof(short) + (players.Length * sizeof(short)) + playersLength;
        byte[] finalBytes = new byte[finalLength];

        index = 0;
        Protocol.Serialize((short)playerOnTurnLength, finalBytes, ref index);
        Array.Copy(playerOnTurnBytes, 0, finalBytes, index, playerOnTurnLength);
        index += playerOnTurnLength;
        Protocol.Serialize((short)players.Length, finalBytes, ref index);
        for (int i = 0; i < players.Length; i++)
        {
            Protocol.Serialize(playersLengthArray[i], finalBytes, ref index);
        }
        Array.Copy(playersBytes, 0, finalBytes, index, playersLength);

        outStream.Write(finalBytes, 0, finalLength);

        return (short)finalLength;
    }

    public static object Deserialize(StreamBuffer inStream, short length)
    {
        GameState gameState = new GameState();

        // Deserialize size of playerOnTurn
        int index = 0;
        byte[] playerOnTurnLengthBytes = new byte[sizeof(short)];
        inStream.Read(playerOnTurnLengthBytes, 0, sizeof(short));
        short playerOnTurnLength;
        Protocol.Deserialize(out playerOnTurnLength, playerOnTurnLengthBytes, ref index);

        // Deserialize playerOnTurn
        byte[] playerOnTurnBytes = new byte[100];
        inStream.Read(playerOnTurnBytes, 0, playerOnTurnLength);
        Player playerOnTurn = (Player)PlayerSerializer.Deserialize(new StreamBuffer(playerOnTurnBytes), playerOnTurnLength);
        index += playerOnTurnLength;

        // Deserialize number of players
        index = 0;
        byte[] playersSizeBytes = new byte[sizeof(short)];
        inStream.Read(playersSizeBytes, 0, sizeof(short));
        short playersSize;
        Protocol.Deserialize(out playersSize, playersSizeBytes, ref index);

        // Deserialize size of each player array
        short[] playersLengthBytes = new short[playersSize];
        for (int i = 0; i < playersSize; i++)
        {
            index = 0;
            byte[] bytes = new byte[sizeof(short)];
            inStream.Read(bytes, 0, sizeof(short));
            short size;
            Protocol.Deserialize(out size, bytes, ref index);
            playersLengthBytes[i] = size;
        }

        // Deserialize each player
        Player[] players = new Player[playersSize];
        for (int i = 0; i < playersSize; i++)
        {
            byte[] bytes = new byte[playersLengthBytes[i]];
            inStream.Read(bytes, 0, playersLengthBytes[i]);
            Player p = (Player)PlayerSerializer.Deserialize(new StreamBuffer(bytes), playersLengthBytes[i]);
            index += playersLengthBytes[i];
            players[i] = p;
        }

        gameState.PlayerOnTurn = playerOnTurn;
        gameState.Players = players;

        return gameState;
    }

}
