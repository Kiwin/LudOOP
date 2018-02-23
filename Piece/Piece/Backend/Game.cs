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
        private Player CurrentPlayer;
        private Dice Die;
        private RuleSet rules;
        private static ConsoleActorMatrix matrix = new ConsoleActorMatrix();

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

            Die = new Dice(sizeOfDie);
            ResourceManager.Initialize(piecesPerPlayer);
            ResourceManager.Board = new GameBoard();
            this.rules = rules;
        }

        public void NextTurn()
        {
            int currentPlayerIndex = ResourceManager.GetPlayers().IndexOf(CurrentPlayer);

            if (currentPlayerIndex >= ResourceManager.GetPlayers().Count)
            {
<<<<<<< HEAD
                CurrentPlayer = ResourceManager.GetPlayers().First();
            } else
=======
                CurrentPlayer = resources.GetPlayers().First();
            }
            else
>>>>>>> caf0a121c13f77368432e6fe1ca9cc83dcd3c441
            {
                CurrentPlayer = ResourceManager.GetPlayers()[currentPlayerIndex + 1];
            }
        }

        public void DetermineFirstPlayer()
        {
            int LargestValue = 0;
            Player luckiestPlayer = ResourceManager.GetPlayers().First();

            for (int i = 0; i < ResourceManager.GetPlayers().Count; i++)
            {
                Player curPlayer = ResourceManager.GetPlayers()[i];

                int roll = Die.Roll();

                if (roll > LargestValue)
                {
                    LargestValue = roll;
                    luckiestPlayer = curPlayer;
                }
            }

            CurrentPlayer = luckiestPlayer;
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
<<<<<<< HEAD
            Tile[] tilesOfType = ResourceManager.Board.maps[0].GetNextTilesOfType(Tiles.TileType.SPAWNPOINT);
            Tile matchingTile = ResourceManager.Board.maps[0].GetFirstTileOfTeam(tilesOfType ,player.Team);
=======
            Tile[] tilesOfType = resources.Board.Maps[0].GetNextTilesOfType(Tiles.TileType.SPAWNPOINT);
            Tile matchingTile = resources.Board.Maps[0].GetFirstTileOfTeam(tilesOfType, player.Team);
>>>>>>> caf0a121c13f77368432e6fe1ca9cc83dcd3c441

            player.SpawnPiece(matchingTile);
            Piece latestPiece = player.GetPieces().Last();
            latestPiece.OnMove += Piece_OnMove;
        }

        private void Piece_OnMove(Piece piece, Tile previousTile, Tile newTile)
        {
            rules.PieceOnTile(newTile, piece);
        }

        public static ConsoleActorMatrix GetConsoleActorMatrix() {
            return matrix;
        }
    }
}




