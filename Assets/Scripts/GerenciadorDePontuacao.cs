using TMPro;
using UnityEngine;

public class GerenciadorDePontuacao : MonoBehaviour
{
    [SerializeField] private TMP_Text potuacaoText;
    [SerializeField] private TMP_Text potuacaoGameOverText;
    [SerializeField] private CloudServices cloudServices;

    private int pontuacao;

    public void AddPontuacao()
    {
        pontuacao++;
        potuacaoText.text = pontuacao.ToString();
        potuacaoGameOverText.text = "SCORE: " + pontuacao;
    }

    public async void RegistrarPontuacao()
    {
        await cloudServices.SalvarPontuacao(pontuacao);
    }
}
