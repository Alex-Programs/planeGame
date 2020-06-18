using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int WorldSizeInChunks = 8;
    public bool doRun;

    Dictionary<Vector3Int, Chunk> chunks = new Dictionary<Vector3Int, Chunk>();

    void Start()
    {
        if (doRun)
        {
            Generate();
        }
    }

    void Generate ()
    {
        for (int x = 0; x < WorldSizeInChunks; x++)
        {
            for (int z = 0; z < WorldSizeInChunks; z++)
            {
                Vector3Int chunkPos = new Vector3Int(x * GameData.ChunkWidth, 0, z * GameData.ChunkWidth);
                chunks.Add(chunkPos, new Chunk(chunkPos));
                chunks[chunkPos].chunkObject.transform.SetParent(transform);
            }
        }
    }
}
