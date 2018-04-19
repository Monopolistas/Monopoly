using System;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using ExitGames.Client.Photon;

namespace Assets.Scripts.Network
{
    public class GameStateSerializer
    {

        public static GameStateMachine GameStateMachine;

        public static short Serialize(StreamBuffer outStream, object customObject)
        {
            GameState gameState = (GameState)customObject;

            // Serialize playerOnTurn to temp byte
            Player playerOnTurn = gameState.PlayerOnTurn;

            int playerOnTurnLength;
            byte[] playerOnTurnBytes;
            PlayerSerializer.CopyToByteArray(playerOnTurn, out playerOnTurnLength, out playerOnTurnBytes);

            // Serialize players to temp byte
            Player[] players = gameState.Players;

            int playersLength = 0;
            short[] playersLengthArray = new short[players.Length];
            int index = 0;

            // Calculate size of array of players
            foreach (Player p in players)
            {
                short pLength = (short)PlayerSerializer.Length(p);
                playersLengthArray[index] = pLength;
                playersLength += pLength;
                index++;
            }

            // Do serialization of players
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

            short isGameOver = (short)(gameState.IsGameOver ? 1 : 0);

            // Write the final array of bytes
            // Size of playerOnTurn array (short) + playerOnTurn array of bytes + number of players in array (short) + array of sizes of players (short) + total size of array of players
            int finalLength = sizeof(short) + playerOnTurnLength + sizeof(short) + (players.Length * sizeof(short)) + playersLength + sizeof(short);
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
            index += playersLength;
            Protocol.Serialize(isGameOver, finalBytes, ref index);

            // Write final array to output
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

            // Deserialize is game over
            short isGameOver;
            index = 0;
            byte[] isGameOverBytes = new byte[sizeof(short)];
            inStream.Read(isGameOverBytes, 0, sizeof(short));
            Protocol.Deserialize(out isGameOver, isGameOverBytes, ref index);

            gameState.PlayerOnTurn = playerOnTurn;
            gameState.Players = players;
            gameState.IsGameOver = isGameOver == 1;

            return gameState;
        }

    }
}
