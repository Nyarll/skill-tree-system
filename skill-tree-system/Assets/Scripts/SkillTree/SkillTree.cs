using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillTree", menuName = "SkillTree/SkillTree")]
public class SkillTree : ScriptableObject
{
    public List<SkillNode> nodes;
}
