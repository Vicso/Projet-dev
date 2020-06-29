package com.sdzee.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.sdzee.bdd.Oracle;
import com.sdzee.beans.Coyote;
import com.sdzee.checkFile.CheckFile;
import com.sdzee.jms.InitJms;
import com.sdzee.jms.MessageReceiver;
import com.sdzee.jms.MessageSender;

public class Test extends HttpServlet {
	public void doGet( HttpServletRequest request, HttpServletResponse response ) throws ServletException, IOException{
		
		/* Création et initialisation du message. */
		String paramAuteur = request.getParameter( "auteur" );
		String message = "Transmission de variables : OK ! " + paramAuteur;
			
		/* Création du bean */
		Coyote premierBean = new Coyote();
		/* Initialisation de ses propriétés */
		premierBean.setNom( "Coyote" );
		premierBean.setPrenom( "Wile E." );
			
		/* Stockage du message et du bean dans l'objet request */
		request.setAttribute( "test", message );
		request.setAttribute( "coyote", premierBean );

		System.out.println("STARTING AND INIT JMS...");
		
		InitJms jmsContext = new InitJms();
		
		MessageReceiver mrThread = new MessageReceiver();
		mrThread.start();
		
		String userInput = "";
		
		while(!userInput.equals("stop")) {
			
		    Scanner myObj = new Scanner(System.in);  // Create a Scanner object
		    System.out.println("Enter message");
		    
		    userInput = myObj.nextLine();  // Read user input
		    System.out.println("Sending: " + userInput + "...");  // Output user input
		    
		    MessageSender ms = new MessageSender(userInput);
		    
		    System.out.println("Message sent !");
		}
		
		System.out.println("Stopping JMS Server...");
		
		jmsContext.closeConnexion();

		/* Transmission de la paire d'objets request/response à notre JSP */
		this.getServletContext().getRequestDispatcher( "/WEB-INF/test.jsp" ).forward( request, response );
	}
}