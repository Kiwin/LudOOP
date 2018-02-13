using System;

namespace Ludoop
{
    public class Piece : IMove
    {
        public enum TeamColor { RED, GREEN, YELLOW, BLUE };

        #region Constructors
        public Piece(TeamColor team, Vector2D position)
        {
            this.Team = team;
            this.Position.X = position.X;
            this.Position.X = position.X;
        }
        #endregion

        #region Getters and Setters
        private TeamColor team;
        public TeamColor Team 
        {
            get { return this.team;}
            set { this.team = value; }
        }
        

        private Vector2D position;
        public Vector2D Position
        {
            get { return this.position; }
            set {
                this.position.X = value.X;
                this.position.X = value.X;
            }
        }
        #endregion

        #region Movement Methods

        public void Move(int tiles)
        {

        }

        public void MoveTo(int tileIndex)
        {
            throw new NotImplementedException();
        }

        public void MoveToMap(int mapIndex, int tileIndex)
        {
            throw new NotImplementedException();
        }
            #endregion

        }
}
