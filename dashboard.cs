using System;
using System.Data;
using System.DT.SqlClient;

class Dashboard
{
    public static void ConnOpen()
    {
	connStr = "Data Source=(local);Initial Catalog=KSTKoperasi;Integrated Security=true";
	SqlConnection conn= new SqlConnection(connStr);
	conn.Open();	
    }       

    public SqlDataReader CountCustomer()
    {     	
     	string queryStr = "SELECT count(*) FROM Account";
	SqlCommand command = new SqlCommand(queryString,connection);
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader AmountByCompany()
    {     	
     	string queryStr = "SELECT AC.CompanyID,C.Name,sum(AC.AccountID) as TotalCust,sum(TotalAmount) as Total " 
		+ "FROM Transaction T INNER JOIN AccountCompany AC ON T.AccountID=AC.AccountID "
		+ "INNER JOIN Company C ON C.ID=AC.CompanyID "
		+ "GROUP BY C.ID";
	SqlCommand command = new SqlCommand(queryString,connection);
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader AmountBySkill()
    {     	     	
	string queryStr = "SELECT AS.SkillID,C.Name,sum(AS.AccountID) as TotalCust,sum(TotalAmount) as Total " 
		+ "FROM Transaction T INNER JOIN AccountSkill AS ON T.AccountID=AS.AccountID "
		+ "INNER JOIN Skill S ON S.ID=AS.SkillID "
		+ "GROUP BY S.ID";
	SqlCommand command = new SqlCommand(queryString,connection);
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader AmountBySchool()
    {     	
	string queryStr = "SELECT AS.SchoolID,C.Name,sum(AS.AccountID) as TotalCust,sum(TotalAmount) as Total " 
		+ "FROM Transaction T INNER JOIN AccountSkill AS ON T.AccountID=AS.AccountID "
		+ "INNER JOIN School S ON S.ID=AS.SchoolID "
		+ "GROUP BY S.ID";
	SqlCommand command = new SqlCommand(queryString,connection);
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader CountMovie(int From, int To)
    {     	
	if From=0 && To=0
	{
     	    string queryStr = "SELECT count(*) FROM Movie WHERE Stock=0";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	}
	else if From=0
	{
	    string queryStr = "SELECT count(*) FROM Movie WHERE Stock<=@to";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@to,to);
	}
	else if To=0
	{
	    string queryStr = "SELECT count(*) FROM Movie WHERE Stock>=@from";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@from,From);
	}
	else
	{
	    string queryStr = "SELECT count(*) FROM Movie WHERE Stock>=@from AND Stock<=@to";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@from,From);
	    command.Parameters.AddWithValue(@to,To);
	}
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader CountCustomerByGender()
    {     	
     	string queryStr = "SELECT A.Gender,sum(TotalAmount) as Total "
		+ "FROM Transaction T INNER JOIN Account A "
		+ "ON T.AccountID=A.ID "
		+ "GROUP BY A.Gender";
	SqlCommand command = new SqlCommand(queryString,connection);
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader CountCustomerByAge()
    {     	
	if From=0
	{
     	    string queryStr = "SELECT sum(TotalAmount) as Total "
		+ "FROM Transaction T INNER JOIN Account A ON T.AccountID=A.ID 
		+ "WHERE DATEDIFF(day,GETDATE(),A.Birthdate)<@to";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@to,to);	
	}
	else if To=0
	{
     	    string queryStr = "SELECT sum(TotalAmount) as Total "
		+ "FROM Transaction T INNER JOIN Account A ON T.AccountID=A.ID 
		+ "WHERE DATEDIFF(day,GETDATE(),A.Birthdate)>@from";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@from,From);
	}
	else
	{
     	    string queryStr = "SELECT sum(TotalAmount) as Total "
		+ "FROM Transaction T INNER JOIN Account A ON T.AccountID=A.ID 
		+ "WHERE DATEDIFF(day,GETDATE(),A.Birthdate)>=@from AND DATEDIFF(day,GETDATE(),A.Birthdate)<=@to";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@from,From);
	    command.Parameters.AddWithValue(@to,To);
	}
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader CountCustomerByBirthPlace()
    {     	
     	string queryStr = "SELECT A.BirthPlace,sum(TotalAmount) as Total "
		+ "FROM Transaction T INNER JOIN Account A "
		+ "ON T.AccountID=A.ID "
		+ "GROUP BY A.BirthPlace";
	SqlCommand command = new SqlCommand(queryString,connection);
	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }

    public SqlDataReader CountCustomerByBalance()
    {     	
	if From=0 && To=0
	{
     	    string queryStr = "SELECT count(*) FROM Account WHERE Balance=0";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	}
	else if From=0
	{
	    string queryStr = "SELECT count(*) FROM Account WHERE Balance<=@to";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@to,to);
	}
	else if To=0
	{
	    string queryStr = "SELECT count(*) FROM Account WHERE Balance>=@from";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@from,From);
	}
	else
	{
	    string queryStr = "SELECT count(*) FROM Account WHERE Balance>=@from AND Balance<=@to";
 	    SqlCommand command = new SqlCommand(queryString,connection);
	    command.Parameters.AddWithValue(@from,From);
	    command.Parameters.AddWithValue(@to,To);
	}	
	SqlDataReader reader = command.ExecuteReader();
	return reader;
    }
}