namespace HotelProject.WebUI.DTOs.ContactDTO
{
    public class CreateContactDTO
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
