using System;

namespace Ludoop
{
    public enum TeamColor { RED, GREEN, YELLOW, BLUE };
    public enum PieceShape { CIRCLE, SQUARE, TRIANGLE, PENTAGON };

    public class Piece : IPiece
    {
        #region Constructors
        public Piece(TeamColor team, PieceShape shape, int x, int y)
        {
            this.Team = team;
            this.Shape = shape;
            this.Position = new Vector2D(x, y);
        }
        #endregion

        #region Getters and Setters
        private TeamColor team;
        private PieceShape shape;

        /// <summary>
        /// Getter and Setter for Piece.team
        /// </summary>
        public TeamColor Team 
        {
            get { return this.team;}
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


        private Vector2D position;
        /// <summary>
        /// Getter and Setter for Piece.position
        /// </summary>
        public Vector2D Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        #endregion

        #region Movement Methods

        /// <summary>
        /// Moves the piece x tiles forward
        /// </summary>
        /// <param name="tiles">how many tiles to move (forwards or backwards)</param>
        public void Move(int tiles)
        {

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
        public Vector2D getId() {
            return new Vector2D((int)team, (int)shape);
        }

    }
}
