using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using api.multitracks.com.Models;
using System.Collections;


namespace api.multitracks.com.database_access_layer
{
    public class db
    {
        // add inserts a new artist into the Artist table 
        public void add(artist cs)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                try
                {
                    SqlCommand com = new SqlCommand("SET IDENTITY_INSERT Artist ON" +
                                                   " INSERT INTO Artist (artistID, dateCreation, title, biography, imageURL, heroURL)" +
                                                   " VALUES (@artistID, @dateCreation, @title, @biography, @imageURL, @heroURL)" +
                                                   " SET IDENTITY_INSERT Artist OFF", con);
                    com.Parameters.AddWithValue("@artistID", cs.artistID);
                    com.Parameters.AddWithValue("@dateCreation", cs.dateCreation);
                    com.Parameters.AddWithValue("@title", cs.title);
                    com.Parameters.AddWithValue("@biography", cs.biography);
                    com.Parameters.AddWithValue("@imageURL", cs.imageURL);
                    com.Parameters.AddWithValue("@heroURL", cs.heroURL);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Diagnostics.Debug.WriteLine(sqlException.Message);
                }
            }
        }

        // search returns an artist by their name
        public DataSet search(string title)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Artist WHERE title ='" + title + "'";
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        // returns a list of all songs with paging support for page number and size 
        public IEnumerable<Song> list (int pageSize, int pageNumber)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand com = new SqlCommand();

                com.Connection = con;
                com.CommandText = "SELECT * FROM Song";
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Song> list = new List<Song>();

                foreach (DataRow row in dt.Rows)
                {
                    Song song = new Song();
                    
                    song.title = row["title"].ToString();
                    
                    list.Add(song);
                }

                const int maxPageSize = 50;

                if(pageSize > maxPageSize)
                {
                    pageSize = maxPageSize;
                }

               return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            
            }
        }
    }
}