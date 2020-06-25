package com.sdzee.bdd;

import java.sql.*;

import oracle.*;

public class Oracle {

		
	public Oracle(){  
		try{
			
		//step1 load the driver class  
		Class.forName("oracle.jdbc.driver.OracleDriver");  
		//Class.forName("oracle.jdbc.OracleDriver");
		
		//step2 create  the connection object  
		Connection con=DriverManager.getConnection(  
		"jdbc:oracle:thin:@localhost:1521:orcl","root","root");  
		  
		//step3 create the statement object  
		Statement stmt=con.createStatement();  
		
		//step4 execute query  
		ResultSet rs=stmt.executeQuery("select * from DICTIONARY");  
		while(rs.next())  
		System.out.println(rs.getNString(1)+"  "/*+rs.getString(2)+"  "+rs.getString(3)*/);  
		  
		//step5 close the connection object  
		con.close();  
		  
		}catch(Exception e)
		{ 
			System.out.println("ERROR !");
			System.out.println(e);
		}  
		
	}

}

