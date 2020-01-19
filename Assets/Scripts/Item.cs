using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //finding the names of the items
    public List<BaseStat> Stats { get; set; }
    public string ObjecSlug { get; set; }

    public Item(List<BaseStat> _Stats, string _ObjectSlug)
    {
        this.Stats = _Stats;
        this.ObjecSlug = _ObjectSlug;
    }
}
