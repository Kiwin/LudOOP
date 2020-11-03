using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludoop.Backend.Tiles;
using Ludoop.View;

namespace Ludoop.Backend
{
    // Game Implements general game flow and handles how the game works INCOMPLETE
    public class Game
    {
        private Player currentPlayer;
        private readonly Dice die;
        private readonly RuleSet rules;
        private static readonly ConsoleRenderConfig renderConfig = new ConsoleRenderConfig();

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="players">Defines the Player classes to be added</param>
        /// <param name="piecesPerPlayer"> defines the amount of pieces per player</param>
        public Game(Player[] players, int piecesPerPlayer, int sizeOfDie, RuleSet rules)
        {
            for (int i = 0; i <= players.Length; i++)
            {
                ResourceManager.AddPlayer(players[i]);
            }

            die = new Dice(sizeOfDie);
            ResourceManager.Initialize(piecesPerPlayer);
            ResourceManager.Board = new LudoGameBoard();
            this.rules = rules;
        }

        public void NextTurn()
        {
            int currentPlayerIndex = ResourceManager.GetPlayers().IndexOf(currentPlayer);

            if (currentPlayerIndex >= ResourceManager.GetPlayers().Count)
            {
                currentPlayer = ResourceManager.GetPlayers().First();
            } else
            {
                currentPlayer = ResourceManager.GetPlayers()[currentPlayerIndex + 1];
            }
        }

        public void DetermineFirstPlayer()
        {
            int largestValue = 0;
            Player luckiestPlayer = ResourceManager.GetPlayers().First();

            for (int i = 0; i < ResourceManager.GetPlayers().Count; i++)
            {
                Player currentPlayer = ResourceManager.GetPlayers()[i];

                int roll = die.Roll();

                if (roll > largestValue)
                {
                    largestValue = roll;
                    luckiestPlayer = currentPlayer;
                }
            }

            currentPlayer = luckiestPlayer;
        }

        public static ConsoleColor GetTeamColor(PlayerTeam team)
        {
            switch (team)
            {
                case PlayerTeam.BLUE: { return ConsoleColor.Blue; }
                case PlayerTeam.GREEN: { return ConsoleColor.Green; }
                case PlayerTeam.RED: { return ConsoleColor.Red; }
                case PlayerTeam.YELLOW: { return ConsoleColor.DarkYellow; }
                default: { return ConsoleColor.White; }
            }
        }

        //TODO: Check if pieces are already on tile and rules applying to such 
        public void MovePiece(Piece piece, int steps)
        {

        }

        public void CreatePiece(Player player, PieceType type)
        {
            Tile[] tilesOfType = ResourceManager.Board.Maps[0].GetNextTilesOfType(Tiles.TileType.SPAWNPOINT);
            Tile matchingTile = ResourceManager.Board.Maps[0].GetFirstTileOfTeam(tilesOfType ,player.Team);
            player.SpawnPiece(matchingTile);
            Piece latestPiece = player.GetPieces().Last();
            latestPiece.OnMove += Piece_OnMove;
        }

        private void Piece_OnMove(Piece piece, Tile previousTile, Tile newTile)
        {
            rules.PieceOnTile(newTile, piece);
        }

        public static ConsoleRenderConfig GetConsoleRenderConfig() {
            return renderConfig;
        }
    }
}




