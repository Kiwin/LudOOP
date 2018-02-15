using Ludoop.Backend;
using System;

namespace Ludoop
{
    public enum PieceShape { CIRCLE, SQUARE, TRIANGLE, PENTAGON };

    public class Piece : IPiece
    {
        #region Constructors
        public Piece(PlayerTeam team, PieceShape shape, Tile tile)
        {
            this.Team = team;
            this.Shape = shape;
            this.Tile = tile;
            OnSpawn(this, tile);
        }
        #endregion

        #region Getters and Setters
        private PlayerTeam team;
        private PieceShape shape;

        /// <summary>
        /// Getter and Setter for Piece.team
        /// </summary>
        public PlayerTeam Team
        {
            get { return this.team; }
            set { this.team = value; }
        }

        /// <summary>
        /// Getter and Setter for Piece.shape
        /// </summary>
        public PieceShape Shape
        {
            get { return this.shape; }
            set { this.shape = value; }
        }

        private Tile tile;

        public Tile Tile
        {
            get { return this.tile; }
            set { this.tile = value; }
        }

        //private Vector2D position;
        ///// <summary>
        ///// Getter and Setter for Piece.position
        ///// </summary>
        //public Vector2D Position
        //{
        //    get { return this.position; }
        //    set { this.position = value; }
        //}
        #endregion

        #region Movement Methods

        /// <summary>
        /// Moves the piece x tiles forward
        /// </summary>
        /// <param name="steps">how many tiles to move (forwards or backwards)</param>
        public void Move(int steps)
        {
            {
                //Check if piece is moving forward.
                bool isForward = steps > 0;
                steps = Math.Abs(steps);

                for (int i = 0; i < steps; i++) {
                    TileStep(i == steps-1, isForward);

                    switch (this.Tile.Type)
                    {
                        case TileType.END:
                            {
                                break;
                            }
                        case TileType.EXIT:
                            {
                                break;
                            }
                        case TileType.GLOBE:
                            {
                                break;
                            }
                        case TileType.SPAWNPOINT:
                            {
                                break;
                            }
                        case TileType.STAR:
                            {
                                break;
                            }
                        case TileType.DEFAULT:
                            {
                                break;
                            }
                        default:
                            {
                                OnTypeNotFound(this.tile.Type, this);
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// Steps the piece on to the next tile in the array
        /// </summary>
        private void TileStep(bool isLastStep, bool isForwards)
        {
            if (!isLastStep)
            {
                OnStep(this, this.Tile, this.Tile.NextTile);
                this.Tile = this.Tile.NextTile;
            }
            else
            {
                OnLastStep(this, this.Tile);
                this.Tile = this.Tile.NextTile;
            }
        }

        /// <summary>
        /// Move to specified tile inside same map
        /// </summary>
        /// <param name="tileIndex">tile index to move to</param>
        public void MoveTo(int tileIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Move piece to map and tile in map
        /// </summary>
        /// <param name="mapIndex">index of map</param>
        /// <param name="tileIndex">index of tile</param>
        public void MoveToMap(int mapIndex, int tileIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
        /// <summary>
        /// Method for getting id of piece.
        /// </summary>
        /// <returns>Id of Piece in form of a Vector2D</returns>
        public Vector2D getId()
        {
            return new Vector2D((int)team, (int)shape);
        }


        public delegate void OnTypeNotFoundHandler(TileType type, Piece piece);
        public event OnTypeNotFoundHandler OnTypeNotFound;

        public delegate void OnStepHandler(Piece piece, Tile currentTile, Tile newTile);
        public event OnStepHandler OnStep;

        public delegate void OnLastStepHandler(Piece piece, Tile currentTile);
        public event OnLastStepHandler OnLastStep;

        public delegate void OnSpawnHandler(Piece piece, Tile spawnTile);
        public event OnSpawnHandler OnSpawn;

    }
}
