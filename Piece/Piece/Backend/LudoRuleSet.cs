using Ludoop.Backend.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ludoop.Backend
{
	public class LudoRuleSet : IRuleSet
	{
		public enum RuleIdentifier { SAFE, JUMP, RETURN, SPAWN };

		public void PieceOnTile(Tile tile, Piece piece)
		{
			// Gets all pieces on the same tile as the Piece being moved
			IEnumerable<Piece> piecesOnSameTile = tile.Map.Tiles.SelectMany(t => ResourceManager.GetPlayers().SelectMany(player => player.GetPieces().Where(p => p.CurrentTile == tile && p != piece)));

			// There can be only one player with a team therefore we can avoid using an IEnumerable all the time and just take the first object
			Player piecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piece.Team).First();

			//foreach(Player player in ResourceManager.GetPlayers())
			//{
			//    foreach(Piece p in player.GetPieces())
			//    {
			//        if(tile == p.CurrentTile)
			//        {


			//        }
			//    }
			//}

			// Determines what rules apply to current move 
			switch (tile.Type)
			{
				case TileType.DEFAULT:
					{
						// If there are more than 1 enemy piece on the tile there mover is removed
						if (piecesOnSameTile.Count() > 1)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piece.RemovePiece();
								piecePlayer.PieceBuffer++;

							}
						}
						// if there are 1 other non alied piece on the tile remove that piece
						else if (piecesOnSameTile.Count() == 1)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piecesOnSameTile.First().RemovePiece();
								Player onSameTilePiecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piecesOnSameTile.First().Team).First();
								onSameTilePiecePlayer.PieceBuffer++;
							}
						}
						break;
					}
				case TileType.END:
					{
						// When the piece reaches its end tile assign flags to reflect this change and increment the win condition
						piece.IsFinished = true;
						piecePlayer.PiecesInEnd++;
						break;
					}
				case TileType.EXIT:
					{

						if (piecesOnSameTile.Count() > 1)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piece.RemovePiece();
								piecePlayer.PieceBuffer++;

							}
						}
						else if (piecesOnSameTile.Count() == 1)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piecesOnSameTile.First().RemovePiece();
								Player onSameTilePiecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piecesOnSameTile.First().Team).First();
								onSameTilePiecePlayer.PieceBuffer++;
							}
							if (piece.Team == ((ExitTile)tile).Team)
							{
								//gets next exit tile
								Tile nextstar = ResourceManager.Board.Maps[0].Tiles.Where(t => t.Type == TileType.STAR).Where(t => tile.Index < t.Index).First();

								piece.WarpTo(nextstar);

								// Gets all pieces on the same tile as the Piece being moved
								IEnumerable<Piece> piecesOnNextStar = nextstar.Map.Tiles.SelectMany(t => ResourceManager.GetPlayers().SelectMany(player => player.GetPieces().Where(p => p.CurrentTile == nextstar && p != piece)));

								if (piecesOnNextStar.Count() > 1)
								{
									if (piecesOnNextStar.First().Team != piece.Team)
									{
										piece.RemovePiece();
										piecePlayer.PieceBuffer++;

									}
								}
								else if (piecesOnNextStar.Count() == 1)
								{
									if (piecesOnNextStar.First().Team != piece.Team)
									{
										piecesOnNextStar.First().RemovePiece();
										Player onNextStarPiecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piecesOnNextStar.First().Team).First();
										onNextStarPiecePlayer.PieceBuffer++;
									}
								}
							}
						}
						else
						{
							if (piece.Team == ((ExitTile)tile).Team)
							{
								//gets next exit tile
								Tile nextstar = ResourceManager.Board.Maps[0].Tiles.Where(t => t.Type == TileType.STAR).Where(t => tile.Index < t.Index).First();

								piece.WarpTo(nextstar);

								// Gets all pieces on the same tile as the Piece being moved
								IEnumerable<Piece> piecesOnNextStar = nextstar.Map.Tiles.SelectMany(t => ResourceManager.GetPlayers().SelectMany(player => player.GetPieces().Where(p => p.CurrentTile == nextstar && p != piece)));

								if (piecesOnNextStar.Count() > 1)
								{
									if (piecesOnNextStar.First().Team != piece.Team)
									{
										piece.RemovePiece();
										piecePlayer.PieceBuffer++;

									}
								}
								else if (piecesOnNextStar.Count() == 1)
								{
									if (piecesOnNextStar.First().Team != piece.Team)
									{
										piecesOnNextStar.First().RemovePiece();
										Player onNextStarPiecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piecesOnNextStar.First().Team).First();
										onNextStarPiecePlayer.PieceBuffer++;
									}
								}
							}
						}
						break;
					}
				case TileType.GLOBE:
					{
						if (piecesOnSameTile.Count() > 0)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piece.RemovePiece();
								piecePlayer.PieceBuffer++;

							}
						}
						break;
					}
				case TileType.SPAWNPOINT:
					{
						if (piecesOnSameTile.Count() > 0)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piece.RemovePiece();
								piecePlayer.PieceBuffer++;

							}
						}
						break;
					}
				case TileType.STAR:
					{
						if (piecesOnSameTile.Count() > 1)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piece.RemovePiece();
								piecePlayer.PieceBuffer++;

							}
						}
						else if (piecesOnSameTile.Count() == 1)
						{
							if (piecesOnSameTile.First().Team != piece.Team)
							{
								piecesOnSameTile.First().RemovePiece();
								Player onSameTilePiecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piecesOnSameTile.First().Team).First();
								onSameTilePiecePlayer.PieceBuffer++;
							}
							//gets next exit tile
							Tile nextexit = ResourceManager.Board.Maps[0].Tiles.Where(t => t.Type == TileType.EXIT).Where(t => tile.Index < t.Index).First();

							piece.WarpTo(nextexit);

							// Gets all pieces on the same tile as the Piece being moved
							IEnumerable<Piece> piecesOnNextExit = nextexit.Map.Tiles.SelectMany(t => ResourceManager.GetPlayers().SelectMany(player => player.GetPieces().Where(p => p.CurrentTile == nextexit && p != piece)));

							if (piecesOnNextExit.Count() > 1)
							{
								if (piecesOnNextExit.First().Team != piece.Team)
								{
									piece.RemovePiece();
									piecePlayer.PieceBuffer++;

								}
							}
							else if (piecesOnNextExit.Count() == 1)
							{
								if (piecesOnNextExit.First().Team != piece.Team)
								{
									piecesOnNextExit.First().RemovePiece();
									Player onNextExitPiecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piecesOnNextExit.First().Team).First();
									onNextExitPiecePlayer.PieceBuffer++;
								}
							}

						}
						else
						{
							//gets next exit tile
							Tile nextexit = ResourceManager.Board.Maps[0].Tiles.Where(t => t.Type == TileType.EXIT).Where(t => tile.Index < t.Index).First();

							piece.WarpTo(nextexit);

							// Gets all pieces on the same tile as the Piece being moved
							IEnumerable<Piece> piecesOnNextExit = nextexit.Map.Tiles.SelectMany(t => ResourceManager.GetPlayers().SelectMany(player => player.GetPieces().Where(p => p.CurrentTile == nextexit && p != piece)));

							if (piecesOnNextExit.Count() > 1)
							{
								if (piecesOnSameTile.First().Team != piece.Team)
								{
									piece.RemovePiece();
									piecePlayer.PieceBuffer++;

								}
							}
							else if (piecesOnNextExit.Count() == 1)
							{
								if (piecesOnNextExit.First().Team != piece.Team)
								{
									piecesOnNextExit.First().RemovePiece();
									Player onNextExitPiecePlayer = ResourceManager.GetPlayers().Where(player => player.Team == piecesOnNextExit.First().Team).First();
									onNextExitPiecePlayer.PieceBuffer++;
								}
							}


						}
						break;
					}
				default:
					{
						break;
					}
			}
		}
	}
}
