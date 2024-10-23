namespace Cohere.Models;

public class ChatRequest: ICohereRequest
{
    // Visit https://docs.cohere.com/reference/chat#request for more information on the input fields

    // <summary>
    // The model to use for text generation
    // </summary>
    public string? Model { get; set; } = "command-r-plus";

    // <summary>
    // A list of chat messages in chronological order, representing a conversation between the user and the model. 
    // Roles include "user", "assistant", "tool" and "system"
    // </summary>
    public required string Messages { get; set; }

    // <summary>
    // Specifies whether the model should stream responses or return them all at once
    // </summary>
    public bool? Stream { get; set; }

    // <summary>
    // A list of available tools (functions) that the model may suggest invoking before producing a text response
    // </summary>
    public List<object>? Tools { get; set; }

    // <summary>
    // A list of relevant documents that the model can cite to generate a more accurate reply
    // </summary>
    public List<object>? Documents { get; set; }

    // <summary>
    // Options for controlling citation generation
    // </summary>
    public object? CitationOptions { get; set; }

    // <summary>
    // Configuration for forcing the model output to adhere to the specified format
    // </summary>
    public object? ResponseFormat { get; set; }

    // <summary
    // The safety mode to use for text generation
    // Allowed values are CONTEXTUAL, STRICT, OFF
    // </summary>
    public Enum? SafetyMode { get; set; }

    // <summary>
    // The number of tokens to generate
    // </summary>
    public int? MaxTokens { get; set; }

    // <summary>
    // A list of up to 5 strings that the model will use to stop generation
    // </summary>
    public List<string>? StopSequences { get; set; }

    // <summary>
    // A non-negative float that tunes the degree of randomness in generation
    // </summary>
    public double? Temperature { get; set; }

    // <summary>
    // A non-negative integer that seeds the random number generator
    // </summary>
    public int? Seed { get; set; }

    // <summary>
    // Used to reduce repetitiveness of generated tokens
    // </summary>
    public double? FrequencyPenalty { get; set; }

    // <summary>
    // Used to reduce repetitiveness of generated tokens
    // </summary>
    public double? PresencePenalty { get; set; }

    // <summary>
    // Ensures only the top k most likely tokens are considered for generation at each step
    // </summary>
    public double? K { get; set; }

    // <summary>
    // Ensures that only the most likely tokens, with total probability mass of p, are considered for generation at each step
    // </summary>
    public double? P { get; set; }
}