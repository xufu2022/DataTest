using System.ComponentModel.DataAnnotations.Schema;

namespace Net5Features.NoRelationProperties;

public enum Stages { None, One, Two, Three }

[Flags]
public enum FlagEnum { None = 0, Flag1 = 1, Flag2 = 2, Flag3 = 4 }

public class ValueConversionExample
{
    public int Id { get; set; }

    public Stages Stage { get; set; }

    [Column(TypeName = "varchar(5)")]
    public Stages StageViaAttribute { get; set; }

    public Stages StageViaFluent { get; set; }

    public Stages? StageCanBeNull { get; set; }

    public FlagEnum EnumFlags { get; set; }

    public DateTime DateTimeUtc { get; set; }

    public DateTime DateTimeUtcUtcOnReturn { get; set; }
    public DateTime DateTimeUtcSaveAsString { get; set; }
}