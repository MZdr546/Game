using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Lines", fileName = "NPC_")]
public class NPC_Dialogue : ScriptableObject
{
    public List<string> lines;
    public List<string> NpcLines, NpcLineQuest, NpcLineComplitedQuest, NpcLineKillQuest, NpcLineComplitedKillQuest;
}
