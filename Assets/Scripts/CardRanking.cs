using TMPro;
using UnityEngine;

public class CardRanking : MonoBehaviour
{
    [SerializeField] private TMP_Text posicaoText;
    [SerializeField] private TMP_Text usernameText;
    [SerializeField] private TMP_Text scoreText;

    public void IniciarCard(int posicao, string username, int score)
    {
        posicaoText.text = posicao + "°";
        usernameText.text = username;
        scoreText.text = score.ToString();
    }
}
