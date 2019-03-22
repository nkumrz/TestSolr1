using CommonServiceLocator;
using SolrNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for common
/// </summary>
public class common
{
    public common()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void LoadData()
    {
        string csvFilePath = HttpContext.Current.Server.MapPath(@"~/UploadedCSVFiles//data.csv");
        string csvData = File.ReadAllText(csvFilePath);
        var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Home>>();
        //Execute a loop over the rows.  
        foreach (string row in csvData.Split('\n'))
        {
            if (!string.IsNullOrEmpty(row))
            {
                //Execute a loop over the columns.  
                string[] cell = row.Split(',');
                Home home = new Home();
                home.ID = cell[0];
                home.Name = cell[1];
                home.Size = cell[2];
                home.Price = Convert.ToDouble(cell[3]);
                home.Address = cell[4];
                home.Possession = cell[5];
                home.PossessionDate = Convert.ToDateTime(cell[6]);
                home.Bed = cell[7];
                home.Bath = cell[8];
                home.Status = cell[9];
                home.Community = cell[10];
                home.Quadrant = cell[11];
                home.City = cell[12];
                home.Style = cell[13].Replace("\n","");
                solr.Add(home);
            }
        }
        solr.Commit();
    }
}