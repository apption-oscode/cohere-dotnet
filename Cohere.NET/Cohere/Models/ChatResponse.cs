namespace Cohere.Models;

public class ChatResponse: ICohereResponse
{
    // Visit https://docs.cohere.com/reference/chat#response for more information on the output fields

    // <summary>
    // Unique identifier for the generated reply
    // </summary>
    public required string Id { get; set; }

    // <summary>
    // The reason a chat request has finished
    // Possible values areCOMPLETE, STOP_SEQUENCE, MAX_TOKENS, TOOL_CALL, ERROR
    // </summary>
    public required Enum FinishReason { get; set; }

    // <summary>
    //  A message from the assistant role can contain text and tool call information.
    // </summary>
    public object? Message { get; set; }

    // <summary>
    // Summary of billed units and tokens used for both the input and output of the request
    // </summary>
    public object? Usage { get; set; }
}