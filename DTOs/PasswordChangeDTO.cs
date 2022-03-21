namespace BDMS_APIs.DTOs
{
    public class PasswordChangeDTO
    {
        public string UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}