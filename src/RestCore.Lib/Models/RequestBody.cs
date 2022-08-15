using System.Text;

namespace RestCore.Lib.Models;

public sealed class RequestBody
{
    public string Content { get; set; }
    public Encoding Encode { get; set; } = Encoding.UTF8;
    public string MediaType { get; set; } = "application/json";

    public RequestBody(string content, Encoding? encode = null, string? mediaType = null)
    {
        Content = content;

        if (encode != null)
            Encode = encode;

        if (!string.IsNullOrWhiteSpace(mediaType))
            MediaType = mediaType;
    }

    public override string ToString()
    {
        return $"Encode: {Encode.EncodingName}, Content-Type: {MediaType}, Content: {Content}";
    }

    internal HttpContent? GetHttpContent()
    {
        return new StringContent(this.Content, this.Encode, this.MediaType);
    }
}
