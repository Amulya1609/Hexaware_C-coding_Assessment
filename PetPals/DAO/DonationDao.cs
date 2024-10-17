using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using System.Data.SqlClient;

namespace DAO
{
    public class DonationDao : IDonationDao
    {
        public Donation GetDonationByID(int donationId)
        {
            Donation donation = null;

            string cnstr = DBPropertyUtil.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Donations WHERE DonationID = @DonationID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@DonationID", donationId);

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    donation = new CashDonation(
                        (string)reader["DonorName"],
                        (decimal)reader["DonationAmount"],
                        (DateTime)reader["DonationDate"]
                    )
                    {
                        DonationID = (int)reader["DonationID"]
                    };
                }

                sqlConnection.Close();
            }

            return donation;
        }
        public void RecordDonation(CashDonation cashDonation)
        {
            string cnstr = DBPropertyUtil.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"
            INSERT INTO Donations (DonorName, DonationAmount, DonationDate, DonationType) 
            VALUES (@DonorName, @DonationAmount, @DonationDate, @DonationType)"; 
                cmd.Connection = sqlConnection;

                
                cmd.Parameters.AddWithValue("@DonorName", cashDonation.DonorName);
                cmd.Parameters.AddWithValue("@DonationAmount", cashDonation.DonationAmount);
                cmd.Parameters.AddWithValue("@DonationDate", cashDonation.DonationDate);
                cmd.Parameters.AddWithValue("@DonationType", "Cash"); 

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        
        public List<Donation> GetAllDonations()
        {
            List<Donation> donations = new List<Donation>();

            string cnstr = DBPropertyUtil.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Donations";
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var donation = new CashDonation(
                        (string)reader["DonorName"],
                        (decimal)reader["DonationAmount"],
                        (DateTime)reader["DonationDate"]
                    )
                    {
                        DonationID = (int)reader["DonationID"]
                    };
                    donations.Add(donation);
                }

                sqlConnection.Close();
            }

            return donations;
        }

       
        public void AddDonation(Donation donationData)
        {
            string cnstr = DBPropertyUtil.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            { 
            SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Donations (DonorName,DonationAmount, DonationDate) 
                                VALUES (@DonorName, @DonationAmount, @DonationDate)";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@DonorName", donationData.DonorName);
                cmd.Parameters.AddWithValue("@DonationAmount", donationData.DonationAmount);
                cmd.Parameters.AddWithValue("@DonationDate", donationData.DonationDate);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        
        public void UpdateDonation(Donation donationData)
        {
            string cnstr = DBPropertyUtil.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Donations SET 
                                DonorName = @DonorName, 
                                DonationAmount = @DonationAmount, 
                                DonationDate = @DonationDate 
                                WHERE DonationID = @DonationID";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@DonorName", donationData.DonorName);
                cmd.Parameters.AddWithValue("@DonationAmount", donationData.DonationAmount);
                cmd.Parameters.AddWithValue("@DonationDate", donationData.DonationDate);
                cmd.Parameters.AddWithValue("@DonationID", donationData.DonationID);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

       
        public void DeleteDonation(int donationId)
        {
            string cnstr = DBPropertyUtil.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Donations WHERE DonationID = @DonationID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@DonationID", donationId);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

    }
}
     