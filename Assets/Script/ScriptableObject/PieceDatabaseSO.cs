using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "MatchGame/Piece Database")]
public class PieceDatabaseSO : ScriptableObject
{
    public string databaseId;
    public Sprite mainSprite;
    public List<PieceData> pieces;
}

