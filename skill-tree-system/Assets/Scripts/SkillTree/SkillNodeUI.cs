using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillNodeUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Button button;

    private SkillNode skillNode;

    public void Initialize(SkillNode node)
    {
        skillNode = node;
        iconImage.sprite = node.icon;

        UpdateVisual();
        button.onClick.AddListener(OnClick);
    }

    private void UpdateVisual()
    {
        iconImage.color = skillNode.isUnlocked ? Color.white : Color.gray;
    }

    private void OnClick()
    {
        if (!skillNode.isUnlocked && CanUnlock(skillNode))
        {
            skillNode.isUnlocked = true;
            UpdateVisual();
        }
    }

    private bool CanUnlock(SkillNode node)
    {
        foreach (var connected in node.connectedNodes)
        {
            if (connected.isUnlocked)
                return true;
        }
        return false;
    }
}
