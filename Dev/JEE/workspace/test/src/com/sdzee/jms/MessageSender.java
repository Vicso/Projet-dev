package com.sdzee.jms;

import javax.jms.Connection;
import javax.jms.Destination;
import javax.jms.JMSException;
import javax.jms.MessageProducer;
import javax.jms.Session;
import javax.jms.TextMessage;

import org.apache.activemq.ActiveMQConnectionFactory;

public class MessageSender {

	protected static final String url = "tcp://localhost:61617";
	
	 public MessageSender(String messageToSend) {

		 Connection connection = null;
		 try {

			 ActiveMQConnectionFactory factory = new ActiveMQConnectionFactory(
			 url);
			 
			 connection = factory.createConnection();
			 Session session = connection.createSession(false,
			 Session.AUTO_ACKNOWLEDGE);
			 Destination destination = session.createTopic("jms/topic/ITExpertsTopic");	 
			 MessageProducer producer = session.createProducer(destination);
			 TextMessage msg = session.createTextMessage();
			 String input = messageToSend;
			 msg.setText(input);
			 producer.send(msg);
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
