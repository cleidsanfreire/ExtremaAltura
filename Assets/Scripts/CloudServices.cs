using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;

public class CloudServices : MonoBehaviour
{
    [SerializeField] private GameObject erroLoginPopupPanel;

    public async Task SignUpAnonymouslyAsync()
    {
        if (AuthenticationService.Instance.IsSignedIn) return;

        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            if (AuthenticationService.Instance.PlayerName == "" || AuthenticationService.Instance.PlayerName == null)
            {
                await AtualizarUsername("Player");
                Debug.Log(AuthenticationService.Instance.PlayerName);
            }

            Debug.Log("Sign in anonymously succeeded!");

            // Shows how to get the playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

        }
        catch
        {
            erroLoginPopupPanel.SetActive(true);
        }
    }

    public void TenteNovamente()
    {
        erroLoginPopupPanel.SetActive(false);
         SignUpAnonymouslyAsync();
    }


    public async Task AtualizarUsername(string username)
    {
        await AuthenticationService.Instance.UpdatePlayerNameAsync(username);
    }

    public string GetUsername()
    {
        return AuthenticationService.Instance.PlayerName;
    }

    public async Task SalvarPontuacao(int pontuacao)
    {
        await LeaderboardsService.Instance.AddPlayerScoreAsync("pontuacoes", pontuacao);
    }
    public async Task<List<JogadorRanking>> GetPontuacoes()
    {
        var scoresResponse = await LeaderboardsService.Instance.GetScoresAsync("pontuacoes");
        
        List<JogadorRanking> jogadoresRanking = new List<JogadorRanking>();

        foreach(LeaderboardEntry entry in scoresResponse.Results)
        {
            JogadorRanking jogador = new JogadorRanking();
            jogador.posicao = entry.Rank;
            jogador.username = entry.PlayerName;
            jogador.pontuacao = (int) entry.Score;

            jogadoresRanking.Add(jogador);
        }

        return jogadoresRanking;
    }

    public async Task<int> GetPontuacaoJogador()
    {
       try
        {
            var result = await LeaderboardsService.Instance.GetPlayerScoreAsync("pontuacoes");

            return (int)result.Score;
        }
    catch
        {
            return 0;
        }
    }


}
