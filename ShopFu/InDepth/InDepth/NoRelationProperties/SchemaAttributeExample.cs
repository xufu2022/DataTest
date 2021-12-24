using System.ComponentModel.DataAnnotations.Schema;

namespace InDepth.NoRelationProperties;

[Table("SchemaAttribute", Schema = "Schema1")]
public class SchemaAttributeExample
{
    public int Id { get; set; }
}