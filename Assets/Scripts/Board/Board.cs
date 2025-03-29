using UnityEngine;

public class Board : Singleton<Board>
{
    public Texture2D texture;
    public float radius;
    public int textureInfoColorIncrement;

    public Board(Texture2D texture, float radius)
    {
        this.texture = texture;
        this.radius = radius;
    }

    public BoardScoreInfo GetScore(Vector3 position, int player)
    {
        if (texture == null)
        {
            Debug.LogError("Texture is not assigned.");
            return new BoardScoreInfo(0, 0);
        }

        float u = position.x / (2 * radius) + 0.5f;
        float v = position.z / (2 * radius) + 0.5f;

        int x = Mathf.Clamp(Mathf.RoundToInt(u * texture.width), 0, texture.width - 1);
        int y = Mathf.Clamp(Mathf.RoundToInt(v * texture.height), 0, texture.height - 1);

        Color pixelColor = texture.GetPixel(x, y);

        int score = Mathf.RoundToInt(pixelColor.r * 255 / textureInfoColorIncrement);
        int slice = Mathf.RoundToInt(pixelColor.g * 255 / textureInfoColorIncrement) -1;

        if(slice != (player-1+2)%4){//Free for all scoring
            score = 0;
        }

        return new BoardScoreInfo(score, slice+1);
    }
}

public struct BoardScoreInfo
{
    public int Score;
    public int Slice;

    public BoardScoreInfo(int score, int slice)
    {
        Score = score;
        Slice = slice;
    }
}