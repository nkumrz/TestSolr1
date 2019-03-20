using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Home
/// </summary>
public class Home
{
    [SolrUniqueKey("id")]
    public string ID { get; set; }

    [SolrField("name")]
    public string Name { get; set; }

    [SolrField("size")]
    public string Size { get; set; }

    [SolrField("price")]
    public double Price { get; set; }

    [SolrField("address")]
    public string Address { get; set; }

    [SolrField("possession")]
    public string Possession { get; set; }

    [SolrField("possessionDate")]
    public DateTime PossessionDate { get; set; }

    [SolrField("bed")]
    public string Bed { get; set; }

    [SolrField("bath")]
    public string Bath { get; set; }

    [SolrField("status")]
    public string Status { get; set; }

    [SolrField("community")]
    public string Community { get; set; }

    [SolrField("quadrant")]
    public string Quadrant { get; set; }

    [SolrField("city")]
    public string City { get; set; }

    [SolrField("style")]
    public string Style { get; set; }

    //[SolrField("inStock")]
    //public bool InStock { get; set; }

    
    //[SolrField("weight")]
    //public double? Weight { get; set; } // nullable property, it might not be defined on all documents.
    public Home()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}