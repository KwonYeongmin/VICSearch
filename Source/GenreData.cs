using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreData
{
    public int Index { get; private set; }
    public string Keyword { get; private set; }

    public GenreData(int idx, string keyword)
    {
        Index = idx;
        Keyword = keyword;
    }
}

