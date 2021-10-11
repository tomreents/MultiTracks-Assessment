using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
public partial class artistDetails : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        try
        {
            // set stored procedure "GetArtistDetails" parameter @artistID
            sql.Parameters.Add("@artistID", 165);

            var data = sql.ExecuteStoredProcedureDS("GetArtistDetails");
            // data set for top of page 
            artistData.DataSource = data.Tables[0];
            artistData.DataBind();
            // data set for artist songs 
            artistData1.DataSource = data.Tables[1];
            artistData1.DataBind();
            // data set for artist albums
            artistData2.DataSource = data.Tables[2];
            artistData2.DataBind();
            // data set for biography 
            artistData3.DataSource = data.Tables[0];
            artistData3.DataBind();


        }
        catch
        {

        }
    }
}