namespace Cohere.Models;

public class RerankResponse: ICohereResponse
{
    // Visit https://docs.cohere.com/reference/rerank#response for more information on the output fields

    // <summary>
    // An ordered list of ranked documents
    // </summary>
    public required List<object> Results { get; set; }

    // <summary>
    // A unique identifier for the reranking request
    // </summary>
    public string? Id { get; set; }

    // <summary>
    // Summary of billed units and tokens used for both the input and output of the request as well as miscellaneous information
    // </summary>
    public object? Meta { get; set; }
}