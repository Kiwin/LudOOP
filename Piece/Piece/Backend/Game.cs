using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludoop.Backend.Tiles;

namespace Ludoop.Backend
{
    // Game Implements general game flow and handles how the game works INCOMPLETE
    public class Game
    {
        private ResourceManager resources = new ResourceManager();
        private Player CurrentPlayer;
        private Dice Die;
        private RuleSet rules;

        /// <summary>
        /// Initializes the Game Class
        /// </summary>
        /// <param name="players">Defines the Player classes to be added</param>
        /// <param name="piecesPerPlayer"> defines the amount of pieces per player</param>
        public Game(Player[] players, int piecesPerPlayer, int sizeOfDie, RuleSet rules)
        {
            for (int i = 0; i <= players.Length; i++)
            {
                resources.AddPlayer(players[i]);
            }

            Die = new Dice(sizeOfDie);
            resources.Initialize(piecesPerPlayer);
            resources.Board = new GameBoard();
            this.rules = rules;
        }

        public void NextTurn()
        {
            int currentPlayerIndex = resources.GetPlayers().IndexOf(CurrentPlayer);

            if (currentPlayerIndex >= resources.GetPlayers().Count)
            {
                CurrentPlayer = resources.GetPlayers().First();
            } else
            {
                CurrentPlayer = resources.GetPlayers()[currentPlayerIndex + 1];
            }
        }

        public void DetermineFirstPlayer()
        {
            int LargestValue = 0;
            Player luckiestPlayer = resources.GetPlayers().First();

            for (int i = 0; i < resources.GetPlayers().Count; i++)
            {
                Player curPlayer = resources.GetPlayers()[i];

                int roll = Die.Roll();

                if (roll > LargestValue)
                {
                    LargestValue = roll;
                    luckiestPlayer = curPlayer;
                }
            }

            CurrentPlayer = luckiestPlayer;
        }

        public static ConsoleColor GetTeamColor(PlayerTeam team) {
            switch (team) {
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
            Tile[] tilesOfType = resources.Board.maps[0].GetNextTilesOfType(Tiles.TileType.SPAWNPOINT);
            Tile matchingTile = resources.Board.maps[0].GetFirstTileOfTeam(tilesOfType ,player.Team);

            player.SpawnPiece(matchingTile);
            Piece latestPiece = player.GetPieces().Last();
            latestPiece.OnMove += Piece_OnMove;
        }

        private void Piece_OnMove(Piece piece, Tile previousTile, Tile newTile)
        {
            rules.PieceOnTile(newTile, piece);
        }
    }
}

                


