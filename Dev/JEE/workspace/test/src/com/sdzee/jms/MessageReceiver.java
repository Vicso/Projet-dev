package com.sdzee.jms;

import java.util.concurrent.TimeUnit;

import javax.jms.JMSException;
import javax.jms.MessageConsumer;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.jms.Topic;
import javax.jms.TopicConnection;

import org.apache.activemq.ActiveMQConnectionFactory;

public class MessageReceiver {

	protected static final String url = "tcp://localhost:61617";

	 public MessageReceiver() {

		 TopicConnection connection = null;
		 try {
			 ActiveMQConnectionFactory factory = new ActiveMQConnectionFactory(
			 url);
			 connection = factory.createTopicConnection();
			 connection.setClientID("durable");
			 connection.start();
			 MessageConsumer consumer = null;
			 Session session = connection.createTopicSession(false,
			 Session.AUTO_ACKNOWLEDGE);
			 Topic topic = session.createTopic("jms/topic/ITExpertsTopic");
			 //Queue queue session.createQueue(arg0)
			 //Topic topic = session.createTopic("topic://pute");
			 consumer = session.createDurableSubscriber(topic, "mySub");
			 // consumer.setMessageListener(new ReceiverListener());
		
			 // System.out.println(" Waiting for Message ...");
			 // while(true){
			 // Thread.sleep(1000);
			 // }
			 while (true) {
				 TextMessage message = (TextMessage) consumer.receive();
				 System.out.println(message.getText());
				 
				//break;
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
