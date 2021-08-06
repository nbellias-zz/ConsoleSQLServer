using ConsoleSQLServer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSQLServer.DAL
{
    public class CountryDAL
    {
        private string _connectionString;
        public CountryDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }
        public List<CountryModel> GetList()
        {
            var listCountryModel = new List<CountryModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    //Using the stored procedure          
                    //SqlCommand cmd = new SqlCommand("SP_COUNTRY_GET_LIST", con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //Using a simple query
                    string query = @"SELECT *
                                     FROM tb_country";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listCountryModel.Add(new CountryModel
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Country = rdr[1].ToString(),
                            Active = Convert.ToBoolean(rdr[2])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCountryModel;
        }

        public List<CountryModel> GetList(string str)
        {
            var listCountryModel = new List<CountryModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    //Using the stored procedure          
                    //SqlCommand cmd = new SqlCommand("SP_COUNTRY_GET_LIST", con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //Using a simple query
                    string query = @"SELECT *
                                     FROM tb_country
                                     WHERE country LIKE '%" + str + "%'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listCountryModel.Add(new CountryModel
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Country = rdr[1].ToString(),
                            Active = Convert.ToBoolean(rdr[2])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCountryModel;
        }
    }
}
