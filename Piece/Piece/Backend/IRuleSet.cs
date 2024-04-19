using Ludoop.Backend.Tiles;

namespace Ludoop.Backend
{
	public interface IRuleSet
	{
		void PieceOnTile(Tile tile, Piece piece);
	}
}