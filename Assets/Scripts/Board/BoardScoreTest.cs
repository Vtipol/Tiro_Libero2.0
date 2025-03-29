using UnityEngine;

public class BoardScoreTest : MonoBehaviour
{
    public Board board;
    public int playerID;
    private void FixedUpdate()
    {
        BoardScoreInfo scoreInfo = board.GetScore(transform.position, playerID);
        Debug.Log($"Score: {scoreInfo.Score}, Slice: {scoreInfo.Slice}");
    }
}
