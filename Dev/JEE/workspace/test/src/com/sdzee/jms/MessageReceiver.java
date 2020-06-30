package com.sdzee.jms;

import java.util.ArrayList;
import java.util.List;

import javax.jms.Connection;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.jms.Topic;
import javax.jms.ObjectMessage;
import javax.jms.BytesMessage;

import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.command.ActiveMQObjectMessage;
import org.apache.activemq.command.ActiveMQTextMessage;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.sdzee.checkFile.CheckFile;

public class MessageReceiver extends Thread {

	protected static final String url = "tcp://localhost:61617";
	MessageConsumer consumer = null;
	Connection connection = null;
	
	 public MessageReceiver() {

		 try {
			 ActiveMQConnectionFactory factory = new ActiveMQConnectionFactory(url);
			 //factory.setTrustAllPackages(true);
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
			 
			 CheckFile cf = new CheckFile();
			 cf.loadDictionary();
		 
			 while (true) {
				 //TextMessage message = (TextMessage) consumer.receive();
				 
				 //ObjectMessage message = (ObjectMessage) consumer.receive();
				 
				 
				 
				 //BytesMessage message = (BytesMessage) consumer.receive();
				 
				 
				 
				 Message message = (Message) consumer.receive();
				 
				 
				  try {

					    if (message instanceof BytesMessage) {

					      BytesMessage bytesMessage = (BytesMessage) message;
					      byte[] data = new byte[(int) bytesMessage.getBodyLength()];
					      bytesMessage.readBytes(data);
					      //bytesMessage.
					      System.out.println(new String(data));

					    } else if (message instanceof TextMessage) {

					      TextMessage textMessage = (TextMessage) message;
					      String text = textMessage.getText();
					      //System.out.println(text);
					      JMSMessage itemWithOwner = new ObjectMapper().readValue(text, JMSMessage.class);
					      //System.out.println(itemWithOwner.data.get(0));
					      
					        /*for( String value : itemWithOwner.data ) {
								  String file = value;
								  cf.analysFile(file, );
					        }*/
					        
					      	if(itemWithOwner.ID == 1) {
						        for(int i = 0; i < itemWithOwner.data.size(); i++) {
									  String file = itemWithOwner.data.get(i);
									  String key = itemWithOwner.keys.get(i);
									  cf.analysFile(file, key, itemWithOwner.userId);
						        }
					      	}
					    }

					  } catch (JMSException jmsEx) {
					    jmsEx.printStackTrace();
					  }
				 
				
	

				 
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
