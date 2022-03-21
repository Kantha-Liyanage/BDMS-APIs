namespace BDMS_APIs.DTOs
{
    public class MessageDTO
    {
        public MessageDTO(string value)
        {
            this.Message = value;
        }
        public string Message { get; set; }
    }
}