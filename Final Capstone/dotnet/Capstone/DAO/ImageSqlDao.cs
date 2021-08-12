using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class ImageSqlDao : IImageDao
    {
        private readonly string connectionString;
        public ImageSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Image> GetImages(int id)
        {
            List<Image> images = new List<Image>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT image_id, property_id, image_link, thumbnail " +
                        "FROM images " +
                        "WHERE property_id = @property_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@property_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        images.Add(GetImageFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return images;
        }

        public int AddImage(Image image)
        {
            int imageId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO images (property_id, image_link, thumbnail) " +
                            "OUTPUT INSERTED.image_id VALUES (@property_id, " +
                            "@image_link, @thumbnail);";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@property_id", image.PropertyId);
                    cmd.Parameters.AddWithValue("@image_link", image.Link);
                    cmd.Parameters.AddWithValue("@thumbnail", image.Thumbnail);

                    imageId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return imageId;
        }

        public int UpdateThumbnail(int propertyId, int imageId)
        {
            int success = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "UPDATE images SET thumbnail = 1 " +
                        "WHERE image_id = @image_id; " +
                        "UPDATE images SET thumbnail = 0 " +
                        "WHERE property_id = @property_id AND image_id != @image_id;";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@image_id", imageId);
                    cmd.Parameters.AddWithValue("@property_id", propertyId);

                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return success;
        }

        public int DeleteImage(int id)
        {
            int success = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM images " +
                        "WHERE image_id = @image_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@image_id", id);
                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return success;
        }

        public Image GetImageFromReader(SqlDataReader reader)
        {
            Image i = new Image()
            {
                ImageId = Convert.ToInt32(reader["image_id"]),
                PropertyId = Convert.ToInt32(reader["property_id"]),
                Link = Convert.ToString(reader["image_link"]),
                Thumbnail = Convert.ToBoolean(reader["thumbnail"])
            };
            return i;
        }
    }
}
