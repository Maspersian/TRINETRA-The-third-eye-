using UnityEngine;

public class MaskManager : MonoBehaviour
{
    public int totalPieces = 4;
    private int snappedPieces = 0;

    [Header("Stages")]
    public GameObject stageRound1;
    public GameObject stageRound2;

    [Header("Round 2 Setup")]
    public int completedMaskID = 1; // for now, hardcode
    public GameObject[] completedMaskPrefabs;
    public Transform round2SpawnPoint;

    public void PieceSnapped()
    {
        snappedPieces++;

        if (snappedPieces >= totalPieces)
        {
            MaskCompleted();
        }
    }

    void MaskCompleted()
    {
        Debug.Log("Mask Completed!");

        Debug.Log("StageRound1 is " + stageRound1);
        Debug.Log("StageRound2 is " + stageRound2);

        stageRound1.SetActive(false);
        stageRound2.SetActive(true);

        Instantiate(
            completedMaskPrefabs[completedMaskID - 1],
            round2SpawnPoint.position,
            Quaternion.identity,
            stageRound2.transform
        );
    }
}
