package com.sdzee.jms;

import javax.jms.Connection;
import javax.jms.JMSException;
import javax.jms.MessageConsumer;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.jms.Topic;

import org.apache.activemq.ActiveMQConnectionFactory;

public class MessageReceiver extends Thread {

	protected static final String url = "tcp://localhost:61617";
	MessageConsumer consumer = null;
	Connection connection = null;
	
	 public MessageReceiver() {

		 try {
			 ActiveMQConnectionFactory factory = new ActiveMQConnectionFactory(url);
			 connection = factory.createConnection();
			 connection.start();
			 Session session = connection.createSession(false,Session.AUTO_ACKNOWLEDGE);
			 Topic topic = session.createTopic("jms/topic/ITExpertsTopic");
			 consumer = session.createConsumer(topic);
			 
		 } catch (Exception e) {
			 e.printStackTrace();
		 }
	 }
	 
	 public void run() {

		 try {
		 
		 while (true) {
			 TextMessage message = (TextMessage) consumer.receive();
			 System.out.println("RECEIVED : " + message.getText());
		 }
		 
		 } catch (Exception e) {
			 e.printStackTrace();
		 } finally {
			 try {
				 if (connection != null) {
					 connection.close();
				 }
			 } catch (JMSException e) {
				 e.printStackTrace();
			 }
		 }
	 }
}
