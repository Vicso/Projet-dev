package com.sdzee.checkFile;

import java.util.ArrayList;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.sdzee.bdd.Oracle;
import com.sdzee.jms.JMSMessage;
import com.sdzee.jms.MessageSender;

public class CheckFile {
	
	ArrayList<String> dictionary;
	int currentIndex = 0;
	int resetIndex = 0;
	
	public CheckFile() {
		
	}
	
	public void loadDictionary() {
		
		System.out.println("CHECKING DB...");
		
		Oracle testOracle = new Oracle();
		
		dictionary = testOracle.retrieveDictionary();
	}
	
	public void analysFile(String file, String key, int userId) {
		
		int totalWords;
		int occurenceNumber = 0;
		
		String[] words = file.split("\\s+");
		
		totalWords = words.length;
		
		for(int i = 0; i < words.length; i++) {
		      for (String element : dictionary){
		          if (element.equals(words[i])){
		                occurenceNumber++;
		          }
		       }
		}
		
		if(occurenceNumber > 0) {
			if(totalWords / occurenceNumber <= 2.5) {
				System.out.println("good" + key);
				System.out.println(file);
				
				JMSMessage jmsMsg = new JMSMessage();
				
				String[] test;
				
				jmsMsg.data = new ArrayList<String>();
				jmsMsg.keys = new ArrayList<String>();
				
				jmsMsg.data.add(file);
				jmsMsg.keys.add(key);
				jmsMsg.ID = userId;
				
				String MsgAsStrmsging="";
				try {
					MsgAsStrmsging = new ObjectMapper().writeValueAsString(jmsMsg);
				} catch (JsonProcessingException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
				MessageSender ms = new MessageSender(MsgAsStrmsging);
			}else {
				System.out.println("not bad not terrible" + totalWords + occurenceNumber);
			}
		}
		
		if(resetIndex > 100) {
			System.out.println("done checking " + currentIndex + "----UID : " + userId);
			resetIndex = 0;
		}
		
		currentIndex++;
		resetIndex++;

		
		//System.out.println("TOTAL WORDS : " + totalWords + "OCCURENCE FOUNDED : " + occurenceNumber);
		
		
		
	}

}
