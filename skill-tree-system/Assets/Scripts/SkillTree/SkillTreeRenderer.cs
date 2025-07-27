using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class SkillTreeRenderer : MonoBehaviour
{
    [SerializeField] private SkillTree skillTreeData;
    [SerializeField] private RectTransform content;
    [SerializeField] private GameObject linePrefab;   // UILineRendererがアタッチされたPrefab
    [SerializeField] private GameObject skillNodePrefab;

    private RectTransform lineContainer;

    private Dictionary<SkillNode, SkillNodeUI> nodeUIs = new();

    private static float offset = 128.0f;

    public void DrawConnection(SkillNodeUI from, SkillNodeUI to)
    {
        GameObject lineObj = Instantiate(linePrefab, lineContainer);
        UILineRenderer line = lineObj.GetComponent<UILineRenderer>();

        Vector2 p1 = from.GetComponent<RectTransform>().anchoredPosition;
        Vector2 p2 = to.GetComponent<RectTransform>().anchoredPosition;

        line.Points = new Vector2[] { p1, p2 };
        line.color = Color.gray;
        line.LineThickness = 2.5f;
    }

    void Start()
    {
        CreateLineContainer();
        GenerateSkillNode();
        DrawConnectionLine();
    }

    private void CreateLineContainer()
    {
        GameObject container = new GameObject("LineContainer", typeof(RectTransform));
        container.transform.SetParent(content, false);

        lineContainer = container.GetComponent<RectTransform>();
        lineContainer.anchorMin = new Vector2(0.5f, 0.5f);
        lineContainer.anchorMax = new Vector2(0.5f, 0.5f);
        lineContainer.pivot = new Vector2(0.5f, 0.5f);
        lineContainer.sizeDelta = content.sizeDelta;
        lineContainer.localScale = Vector3.one;
        lineContainer.anchoredPosition = Vector2.zero;

        lineContainer.SetAsFirstSibling();
    }

    private void GenerateSkillNode()
    {
        // ノードを生成
        foreach (var node in skillTreeData.nodes)
        {
            var nodeObj = Instantiate(skillNodePrefab, content);

            RectTransform rt = nodeObj.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(node.position.x * offset, node.position.y * offset);

            var ui = nodeObj.GetComponent<SkillNodeUI>();
            ui.Initialize(node);

            nodeUIs[node] = ui;
        }
    }

    private void DrawConnectionLine()
    {
        // 接続線を描画
        foreach (var node in skillTreeData.nodes)
        {
            foreach (var connected in node.connectedNodes)
            {
                DrawConnection(nodeUIs[node], nodeUIs[connected]);
            }
        }
    }
}
