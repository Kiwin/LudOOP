using System;

namespace Ludoop
{
    public class Piece : IMove, IPosition
    {
        public enum TeamColor { RED, GREEN, YELLOW, BLUE };

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="team">specifies which team the piece is a part of</param>
        /// <param name="position">specifies what position the piece is on</param>
        public Piece(TeamColor team, int x, int y)
        {
            this.Team = team;
            this.Position = new Vector2D(x, y);
        }
        #endregion

        #region Getters and Setters
        private TeamColor team;
        /// <summary>
        /// get and set, team for object
        /// </summary>
        public TeamColor Team 
        {
            get { return this.team;}
            set { this.team = value; }
        }
        

        private Vector2D position;
        /// <summary>
        /// get and set, position for object
        /// </summary>
        public Vector2D Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        #endregion

        #region Movement Methods

        /// <summary>
        /// moves the piece x tiles forward
        /// </summary>
        /// <param name="tiles">how many tiles to move (forwards or backwards)</param>
        public void Move(int tiles)
        {

        }

        /// <summary>
        /// move to specified tile inside same map
        /// </summary>
        /// <param name="tileIndex">tile index to move to</param>
        public void MoveTo(int tileIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// move piece to map and tile in map
        /// </summary>
        /// <param name="mapIndex">index of map</param>
        /// <param name="tileIndex">index of tile</param>
        public void MoveToMap(int mapIndex, int tileIndex)
        {
            throw new NotImplementedException();
        }
            #endregion

        }
}
