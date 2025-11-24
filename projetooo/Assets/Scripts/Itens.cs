using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Itens : MonoBehaviour
{
    public int itemCount;
    public TextMeshProUGUI CountText; // arraste no Inspector, se preferir
    [Tooltip("Nome do GameObject que contém o TextMeshProUGUI (opcional)")]
    public string CountTextObjectName;

    void Start()
    {
        // Se não foi atribuído via Inspector, tenta localizar pelo nome
        if (CountText == null && !string.IsNullOrEmpty(CountTextObjectName))
        {
            GameObject go = GameObject.Find(CountTextObjectName);
            if (go != null)
            {
                CountText = go.GetComponent<TextMeshProUGUI>();
                if (CountText == null)
                    Debug.LogWarning("Itens: GameObject encontrado, mas não contém TextMeshProUGUI: " + CountTextObjectName);
            }
            else
            {
                Debug.LogWarning("Itens: GameObject não encontrado com o nome: " + CountTextObjectName);
            }
        }

        // Se ainda não houver, cria um contador simples em runtime
        if (CountText == null)
        {
            CreateDefaultCounterUI();
        }

        UpdateCounterText();
    }

    void Update()
    {
        // Mantido por compatibilidade; apenas atualiza se referência válida
        if (CountText != null)
            CountText.text = "Coletados: " + itemCount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("itens"))
        {
            Destroy(other.gameObject);
            itemCount++;
            UpdateCounterText();
        }
    }

    private void UpdateCounterText()
    {
        if (CountText != null)
            CountText.text = "Coletados: " + itemCount;
    }

    private void CreateDefaultCounterUI()
    {
        GameObject canvasGO = new GameObject("ItemCounterCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<UnityEngine.UI.CanvasScaler>();
        canvasGO.AddComponent<UnityEngine.UI.GraphicRaycaster>();

        GameObject textGO = new GameObject("ItemCountText_TMP");
        textGO.transform.SetParent(canvasGO.transform, false);
        TextMeshProUGUI tmp = textGO.AddComponent<TextMeshProUGUI>();
        tmp.fontSize = 24;
        tmp.alignment = TextAlignmentOptions.TopLeft;
        tmp.color = Color.white;

        RectTransform rt = tmp.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0f, 1f);
        rt.anchorMax = new Vector2(0f, 1f);
        rt.pivot = new Vector2(0f, 1f);
        rt.anchoredPosition = new Vector2(10f, -10f);
        rt.sizeDelta = new Vector2(300f, 50f);

        CountText = tmp;
    }

    /// <summary>
    /// Permite setar a referência por código em runtime.
    /// </summary>
    public void SetCountText(TextMeshProUGUI tmp)
    {
        CountText = tmp;
        UpdateCounterText();
    }
}
