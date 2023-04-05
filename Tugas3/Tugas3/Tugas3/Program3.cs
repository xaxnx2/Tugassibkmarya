﻿using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Connection;

public class Program3
{
    private static SqlConnection connection;

    private static string conn = "Data Source=DESKTOP-B8BBANV;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False";

    public static void Main()
    {
        //Country
        //GetAllcountry();
        //GetByIdcountry("te");
        //Insertcountry("te","test",2);
        //Updatecountry("te", "test_country", 4);
        //Deletecountry("te");

        //Region
        //GetByIdregion(5);
        //Updateregion(5, "Te");
        //Insertregion(5,"test");
        //Deleteregion(5);
    }

    // GET ALL : country
    public static void GetAllcountry()
    {

        connection = new SqlConnection(conn);
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From country;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("Region : " + reader[2]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Region is Empty!");
        }
        reader.Close();
        connection.Close();
    }

    // GET BY ID : Country
    public static void GetByIdcountry(string id)
    {

        connection = new SqlConnection(conn);

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From country Where id = @id;";

        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@id";
        pid.SqlDbType = System.Data.SqlDbType.VarChar;
        pid.Value = id;
        command.Parameters.Add(pid);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            Console.WriteLine("Id : " + reader[0]);
            Console.WriteLine("Name : " + reader[1]);
            Console.WriteLine("Region : " + reader[2]);

        }
        else
        {
            Console.WriteLine($"id = {id} is not found!");
        }
        reader.Close();
        connection.Close();
    }

    // INSERT : country
    public static void Insertcountry(string id, string name, int region)
    {
        connection = new SqlConnection(conn);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into country (id, name, region) Values (@id, @name, @region);";
            command.Transaction = transaction;

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@id";
            pid.SqlDbType = System.Data.SqlDbType.VarChar;
            pid.Value = id;
            command.Parameters.Add(pid);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter();
            pRegion.ParameterName = "@region";
            pRegion.SqlDbType = System.Data.SqlDbType.Int;
            pRegion.Value = region;
            command.Parameters.Add(pRegion);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    // UPDATE : country
    public static void Updatecountry(string id, string name, int region)
    {
        connection = new SqlConnection(conn);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update country Set name = @name, region = @region Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter();
            pRegion.ParameterName = "@region";
            pRegion.SqlDbType = System.Data.SqlDbType.Int;
            pRegion.Value = region;
            command.Parameters.Add(pRegion);



            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }

    // DELETE : country
    public static void Deletecountry(string id)
    {
        connection = new SqlConnection(conn);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete From country Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        
        
    }


    // GET ALL : Region

    // GET BY ID : Region
    public static void GetByIdregion(int id)
    {

        connection = new SqlConnection(conn);

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From region Where id = @id;";

        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@id";
        pid.SqlDbType = System.Data.SqlDbType.Int;
        pid.Value = id;
        command.Parameters.Add(pid);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            Console.WriteLine("Id : " + reader[0]);
            Console.WriteLine("Name : " + reader[1]);

        }
        else
        {
            Console.WriteLine($"id = {id} is not found!");
        }
        reader.Close();
        connection.Close();
    }

    // INSERT : Region
    public static void Insertregion(int id, string name)
    {
        connection = new SqlConnection(conn);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SET IDENTITY_INSERT region ON; Insert Into region (id, name) Values (@id, @name); SET IDENTITY_INSERT region OFF ;";
            command.Transaction = transaction;

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@id";
            pid.SqlDbType = System.Data.SqlDbType.Int;
            pid.Value = id;
            command.Parameters.Add(pid);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            command.ExecuteNonQuery();
            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    // UPDATE : Region
    public static void Updateregion(int id, string name)
    {
        connection = new SqlConnection(conn);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Update region Set name = @name Where id = @id; ";
        command.Transaction = transaction;

        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@id";
        pid.SqlDbType = System.Data.SqlDbType.Int;
        pid.Value = id;
        command.Parameters.Add(pid);

        SqlParameter pName = new SqlParameter();
        pName.ParameterName = "@name";
        pName.SqlDbType = System.Data.SqlDbType.VarChar;
        pName.Value = name;
        command.Parameters.Add(pName);


        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Update Success!");
        }
        else
        {
            Console.WriteLine($"id = {id} is not found!");
        }
        transaction.Commit();
        connection.Close();

    }
    
    // DELETE : Region
    public static void Deleteregion(int id)
    {
        connection = new SqlConnection(conn);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

  
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete From region Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@id";
            pid.SqlDbType = System.Data.SqlDbType.Int;
            pid.Value = id;
            command.Parameters.Add(pid);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();


    }

}