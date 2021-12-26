using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Features.Relationship.ReDomain
{
    public abstract class Container          //#A
    {
        [Key]
        public int ContainerId { get; set; } //#B

        public int HeightMm { get; set; } //#C
        public int WidthMm { get; set; }  //#C
        public int DepthMm { get; set; }  //#C
    }

    public class ShippingContainer : Container //#D
    {
        public int ThicknessMm { get; set; }   //#E
        public string DoorType { get; set; }   //#E
        public int StackingMax { get; set; }   //#E
        public bool Refrigerated { get; set; } //#E
    }

    public enum Shapes { Rectangle, Bottle, Jar }

    public class PlasticContainer : Container //#D
    {
        public int CapacityMl { get; set; }    //#F
        public Shapes Shape { get; set; }      //#F
        public string ColorARGB { get; set; }  //#F
    }
}
