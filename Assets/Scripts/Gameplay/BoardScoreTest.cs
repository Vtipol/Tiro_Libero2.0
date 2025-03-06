using UnityEngine;

public class BoardScoreTest : MonoBehaviour
{
    public Board board;

    private void FixedUpdate()
    {
        BoardScoreInfo scoreInfo = board.GetScore(transform.position);
        Debug.Log($"Score: {scoreInfo.Score}, Slice: {scoreInfo.Slice}");
    }
}
