using Erk.DTO.Entities;

namespace Erk.Models
{
    public class IlceViewModel
    {
        public Ilce Ilce { get; set; }  // İlçe modelini tutar
        public List<Il> Iller { get; set; }  // Iller listesini tutar

        public IlceViewModel()
        {
            Ilce = new Ilce();
            Iller = new List<Il>();
        }
    }
}
