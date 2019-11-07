using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager
{
    private static int player_count;
    public static int PlayerCount {
        get {
            return player_count;
        }
        set {
            player_count = value;
        }
    }
}
