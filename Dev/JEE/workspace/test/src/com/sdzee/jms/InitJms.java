package com.sdzee.jms;

import java.util.Properties;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.JMSException;
import javax.naming.Context;
import javax.naming.InitialContext;

import org.apache.activemq.broker.BrokerService;

public class InitJms {
	
	static BrokerService broker;
	
	 public InitJms() { //Create a broker and start automatically the MOM Server on the selected PORT from apache tomcat

		 Connection connection = null;
		 
		 try {
			 initBroker();
			 InitialContext jndiContext = new InitialContext(getProp());
			 ConnectionFactory connectionFactory = (ConnectionFactory) jndiContext.lookup("ConnectionFactory");
			 
		 } catch (Exception e) {
			 e.printStackTrace();
		 } finally {
			 try {
				 if (connection != null) {
					 connection.close();
					 System.out.println("Connection ended");
				 }
			 } catch (JMSException e) {
				 e.printStackTrace();
			 }
		 }
	 }
	
	 public static void initBroker() throws Exception {
		 
		 broker = new BrokerService();
		 // configure the broker
		 broker.addConnector("tcp://localhost:61617");
		 broker.start();
	 }
	 
	 public static Properties getProp() {
		 Properties props = new Properties();
		 props.setProperty(Context.INITIAL_CONTEXT_FACTORY,
		 "org.apache.activemq.jndi.ActiveMQInitialContextFactory");
		 props.setProperty(Context.PROVIDER_URL, "tcp://localhost:61617");
		 return props;
	 }
	 
	 public void closeConnexion() {
		 try {
			 broker.stop();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			System.out.println("error");
			return;
		}
		System.out.println("Connexion closed !");
	 }

}
