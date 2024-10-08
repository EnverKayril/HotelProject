using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.ServiceDTO
{
    public class UpdateServiceDTO
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlığını 100 karakterden fazla olamaz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet açıklaması 100 karakterden fazla olamaz.")]
        public string Description { get; set; }
    }
}
