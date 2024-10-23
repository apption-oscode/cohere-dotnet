namespace Cohere.Models;

public class ClassifyResponse: ICohereResponse
{
    // Visit https://docs.cohere.com/reference/classify#response for more information on the output fields

    // <summary>
    // The unique identifier for the classification request
    // </summary>
    public required string Id { get; set; }

    // <summary>
    // The classification results for each input text
    // </summary>
    public required List<object> Classifications { get; set; }

    // <summary>
    // Summary of billed units and tokens used for both the input and output of the request as well as miscellaneous information
    // </summary>
    public object? Meta { get; set; }
}