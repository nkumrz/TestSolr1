using CommonServiceLocator;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                Startup.Container.Clear();
                Startup.InitContainer();
                Startup.Init<Home>("http://localhost:8983/solr/homes");
                common.LoadData();
                var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Home>>();
                solr.BuildSpellCheckDictionary();
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Home>>();

        var results = solr.Query(new SolrQueryByField("name", txtQuery.Text.Trim()), new QueryOptions
        {
            SpellCheck = new SpellCheckingParameters { Collate = true }
           
        });
        if(results.Count > 0)
        {
            ltrmsg.Visible = false;
            RepSearchedResult.DataSource = results;
            RepSearchedResult.DataBind();
        }
        else
        {
            ltrmsg.Visible = true;
            RepSearchedResult.DataSource = null;
            RepSearchedResult.DataBind();
        }
        

        foreach (var sc in results.SpellChecking)
        {
            Console.WriteLine("Query: {0}", sc.Query);
            foreach (var s in sc.Suggestions)
            {
                ltrmsg.Text += s;
                ltrmsg.Visible = true;

            }
        }
    }
}