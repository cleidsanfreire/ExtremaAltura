using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;
using UnityEngine.Events;

public class RemovedorDeAnuncios : MonoBehaviour
{
    private bool removerAnuncio = false;

    [SerializeField] private UnityEvent onRemoverAnuncios;
    
    public bool GetRemoverAnuncios()
    {
        return removerAnuncio;
    }
    public async void SaveCloud()
    {
        var data = new Dictionary<string, object> { { "no_ads", true } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);

        removerAnuncio = true;

        onRemoverAnuncios.Invoke();
    }

    public async void LoadCloudDate()
    {
       try
        {
            var dadoSalvos = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { "no_ads" });
            removerAnuncio = dadoSalvos["no_ads"].Value.GetAs<bool>();

            if (removerAnuncio)
            {
                onRemoverAnuncios.Invoke();
            }
        }
        catch
        {

        }
    }
}
