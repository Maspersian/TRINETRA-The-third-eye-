using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameplayManager : MonoBehaviour
{
    //[SerializeField] private AllPieceDatabasesSO allDatabases;
    [SerializeField] private int databasesToPick = 4;

    private List<PieceDatabaseSO> selectedDatabases = new();
     [SerializeField]private List<PieceDatabaseSO> PieceDatabaseSOs;
     private DragPiece [] piecesObj;  

    void Start()
    {
        piecesObj = FindObjectsOfType<DragPiece>();

        SelectRandomDatabases();
       /*  SpawnMainObjects();
        SpawnSidePieces(); */
        for (int i = 0; i < 4; i++)
        {
            piecesObj[i].pieceID = PieceDatabaseSOs[0].pieces[i].pieceId;
            piecesObj[i].gameObject.GetComponent<Image>().sprite = PieceDatabaseSOs[0].pieces[i].sprite;
            

        }

    }

    void SelectRandomDatabases()
    {
        selectedDatabases.Clear();

        //List<PieceDatabaseSO> temp = new(allDatabases.databases);

       /*  for (int i = 0; i < databasesToPick; i++)
        {
            int index = Random.Range(0, temp.Count);
            selectedDatabases.Add(temp[index]);
            temp.RemoveAt(index); // no duplicates
        } */
    }
    
}
