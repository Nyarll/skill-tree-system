using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillNode", menuName = "SkillTree/SkillNode")]
public class SkillNode : ScriptableObject
{
    public string nodeId;
    public string displayName;
    public string description;
    public Vector2 position;
    public Sprite icon;

    public List<SkillNode> connectedNodes;
    public bool isUnlocked;
}
