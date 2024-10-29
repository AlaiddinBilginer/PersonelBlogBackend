namespace PersonelBlogBackend.Application.Features.Tags.Commands.CreateTag
{
    public class CreateTagCommandResponse
    {
        public string Message { get; set; } = string.Empty;
    }

    public class CreateTagCommandSuccessResponse : CreateTagCommandResponse
    {
        public bool Succeeded { get; set; } = true;
    }

    public class CreateTagCommandErrorResponse : CreateTagCommandResponse
    {
        public bool Succeeded { get; set; } = false;
    }
}
