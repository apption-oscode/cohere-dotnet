namespace Cohere.Types;

/// <summary>
/// The object to be sent to the classify endpoint
/// </summary>
public class ClassifyRequest: ICohereRequest
{
   // Visit https://docs.cohere.com/reference/classify#request for more information on the input fields

    /// <summary>
    /// A list of up to 96 texts to be classified
    /// Each one must be a non-empty string
    /// </summary>
    public required List<string> Inputs { get; set; }

    /// <summary>
    /// An array of examples to provide context to the model
    /// </summary>
    public List<ClassifyExample>? Examples { get; set; }

    /// <summary>
    /// The model to use for text classification
    /// </summary>
    public string? Model { get; set; } = "embed-english-v2.0";

    /// <summary>
    /// The ID of a custom playground preset
    /// </summary>
    public string? Preset { get; set; }

    /// <summary>
    /// Specify how the API will handle inputs longer than the maximum token length
    /// </summary>
    public ClassifyTruncateEnum? Truncate { get; set; }
}