using APIWEB.Models.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace APICLIENT.Services
{
    public interface IService
    {
        Task<List<Serie>> GetSeriesAsync(string nomControleur);
        Task<bool> GetSerieAsync(string nomControlleur, int idSerie);        
        Task<bool> UpdateSerieAsync(string nomControlleur, Serie seriemodif);
        Task<bool> CreateSerieAsync(string nomControlleur, Serie serieACreer);
        Task<bool> DeleteSerieAsyc(string nomControlleur, int idSerie);
        
    }
}