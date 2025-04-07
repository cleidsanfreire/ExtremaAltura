using System;
using TMPro;
using Unity.Services.Core;
using UnityEngine;

public class ControladorLogin : MonoBehaviour
{
    [SerializeField] private CloudServices cloudServices;
    [SerializeField] private TMP_Text usernameText;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_Text recordText;
    [SerializeField] private RemovedorDeAnuncios removedorDeAnuncios;

    private async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await cloudServices.SignUpAnonymouslyAsync();
            removedorDeAnuncios.LoadCloudDate();

            AtualizarUsernameUI();
            AtualizarRecordUI();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void AtualizarUsernameUI()
    {
        string username = cloudServices.GetUsername(); 
        usernameText.text = username;
        usernameInputField.text = username.Substring(0, username.IndexOf("#"));
    }

    public async void SalvarNovoUsername()
    {
        await cloudServices.AtualizarUsername(usernameInputField.text);
        AtualizarUsernameUI();
    }

    public async void AtualizarRecordUI()
    {
        int record = await cloudServices.GetPontuacaoJogador();
        recordText.text = "MEU RECORD: " + record;
    }
}
