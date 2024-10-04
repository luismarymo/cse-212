using System.ComponentModel;
using System.Runtime.Versioning;
using Microsoft.VisualBasic;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] Features {get; set; }
    public class Feature {
        public Properties Properties { get; set;}
    }

    public class Properties {
        public decimal Mag { get; set; }
        public string Place { get; set; }
    }
}