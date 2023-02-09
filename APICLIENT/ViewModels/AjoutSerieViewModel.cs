using APICLIENT.Services;
using APIWEB.Models.EntityFramework;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICLIENT.ViewModels
{

    public class AjoutSerieViewModel: ObservableObject
    {
        public IRelayCommand BtnAjoutSerie { get; }

        

        public AjoutSerieViewModel()
        {
            BtnAjoutSerie = new RelayCommand(ActionAddSerie);

        }
        private void ActionAddSerie()
        {
            Serie serie = new Serie();
            WSService service = new WSService();
            service.CreateSerieAsync("https://apiserieslaulouis.azurewebsites.net/api/series", serie);
        }
    }



}
