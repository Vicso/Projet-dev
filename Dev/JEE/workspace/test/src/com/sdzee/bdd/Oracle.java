package com.sdzee.bdd;

import java.sql.*;
import java.util.ArrayList;

import oracle.*;

public class Oracle {

		
	public Oracle(){
		
		
		
	}
	
	public ArrayList<String> retrieveDictionary() {

		ArrayList<String> dictionary = new ArrayList<String>();
		
		try{
			
		//step1 load the driver class  
		Class.forName("oracle.jdbc.driver.OracleDriver");  
		//Class.forName("oracle.jdbc.OracleDriver");
		
		//step2 create  the connection object  
				Connection con=DriverManager.getConnection("jdbc:oracle:thin:@192.168.8.150:1521:orcl","root","root"); 
				//Connection con=DriverManager.getConnection("jdbc:oracle:thin:@(description=(address_list=(192.168.8.150=(protocol=tcp)(port=1521)(host=prodHost)))(connect_data=(INSTANCE_NAME=orcl)))"); 
		//Connection con=DriverManager.getConnection("jdbc:oracle:thin:@//192.168.8.150:1521/orcl","root","root"); 
		  
		//step3 create the statement object  
		Statement stmt=con.createStatement();  
		
		//step4 execute query  
		ResultSet rs=stmt.executeQuery("select * from DICTIONARY");  
		while(rs.next())  
		//System.out.println(rs.getNString(1)+"  "/*+rs.getString(2)+"  "+rs.getString(3)*/);  
		dictionary.add(rs.getNString(1));
		 
		//step5 close the connection object  
		con.close();
		
		return dictionary;
		  
		}catch(Exception e)
		{ 
			System.out.println("ERROR !");
			System.out.println(e);
			return dictionary;
		}  
		
	}

}

